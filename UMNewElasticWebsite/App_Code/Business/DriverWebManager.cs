using UMNewElasticWebsite.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UMNewElasticWebsite.Business
{
    public class DriverWebManager : BusinessManager
    {
        private static string path_fix = HttpContext.Current.Server.MapPath("~/");

        public bool ExecuteMainRoutine()
        {
            try
            {
                ////JOBS LIST and X is working but the order is different
                ////jobMgrJobSvcImpl j = new JobSvcImpl();
                JobManager jobMgr = new JobManager();
                String[] job_list = jobMgr.selectExpressionNames(); //job_names
                double[] X = jobMgr.selectExpressionDifficulty(); //X
                double[,] new_X = new double[X.Length, 1];
                for (int i = 0; i < X.Length; i++)
                {
                    new_X[i, 0] = X[i];
                }

                //////User Profile (just the user ID, I still need the user self rating)
                //////RecruiteeSvcImpl r = new RecruiteeSvcImpl();
                RecruiteeManager recMgr = new RecruiteeManager();
                String[] recruitee_names = recMgr.selectRecruiteeNames();
                double[] recruitee_skill = recMgr.selectRecruiteeSkills();
                UserProfile[] users_profile = new UserProfile[recruitee_skill.Length];
                for (int i = 0; i < recruitee_skill.Length; i++)
                {
                    users_profile[i] = new UserProfile("", 0);
                    users_profile[i].UserID = recruitee_names[i];
                    users_profile[i].UserRating = recruitee_skill[i];
                }
                //////new_Y
                ElasticManager elasticMgr = new ElasticManager();
                double[,] Y = elasticMgr.SelectRatings(job_list, users_profile);


                ///////////// WRITING VARIABLES IN FILE ////////////
                FromWebToFileManager file = new FromWebToFileManager();
                file.writeFiles(job_list, new_X, users_profile, Y);




                //////Object to Hold Task Parameters
                TaskDimensions task = new TaskDimensions();
                task.num_features = new_X.GetLength(1); //1 is the number of columns
                task.num_jobs_init = job_list.Length;
                task.num_users_init = recruitee_names.Length;

                //////User number to start proccessing
                int user_number = 1;

                //////Load File System Service
                //////IFileSystemSvc svc = new FileSystemSvcImpl();
                FileSystemManager fileSystemManager = new FileSystemManager();

                //////Creating a variable to write in a File the job recommendations and comparisons
                //////Load File Writer
                StreamWriter writeTextResult = fileSystemManager.getResultStreamWriter();
                StreamWriter writeTextAverages = fileSystemManager.getAverageStreamWriter();
                StreamWriter writeText = fileSystemManager.getIdandAvgStreamWriter();
                StreamWriter writeTextDiff = fileSystemManager.getDifficultyStreamWriter();

                double[] users_calculated_raitings = new double[task.num_users_init];

                double total_rating_avg_system = 0;
                double total_similarity_avg_system = 0;
                double total_inaccuracy_system = 0;

                while (user_number <= task.num_users_init)
                {
                    double[,] my_ratings = new double[task.num_jobs_init, 1];
                    double[,] new_Y = new double[task.num_jobs_init, task.num_users_init - 1];
                    double[,] R = new double[task.num_jobs_init, task.num_users_init - 1];

                    for (int i = 0; i < job_list.Length; i++)
                    {
                        int k = 0;
                        for (int n = 0; n < users_profile.Length; n++)
                        {
                            if (n != (user_number - 1))
                            {
                                new_Y[i, k] = Y[i, n];
                                if (Y[i, n] != 0)
                                    R[i, k] = 1;
                                else
                                    R[i, k] = 0;
                                k++;
                            }
                            else
                                my_ratings[i, 0] = Y[i, n];
                        }
                    }


                //    ////Creating a MatLab reference to execute the recommended job script
                //    ////IMatlabSvc matSvc = new MatlabSvcImpl();
                    MatlabManager matlabMgr = new MatlabManager();
                    object[] res = matlabMgr.executeFilter(task, job_list, path_fix + "files", my_ratings, new_Y, R, new_X);


                //    ////Each time creates a  to be used to write the recommended jobs in a file
                    List<TopJobData> mylist = fileSystemManager.writeValuesToFile(writeTextResult, res, job_list, user_number, new_X);


                //    ////Calculate Averages for Jobs for a User
                    DataResult avgs = new DataResult(mylist, mylist.Count, users_profile[user_number - 1]);
                    avgs.AverageForEachJob();
                    fileSystemManager.writeAveragesToFile(avgs, writeTextAverages, users_profile[user_number - 1]);

                    total_rating_avg_system += avgs.Rating_total_avg;
                    total_similarity_avg_system += avgs.Percentage_total_avg;
                    total_inaccuracy_system += avgs.Self_inaccuracy;
                //    ////adding the list at the Dictionary for each user

                //    ////ID and AVGs file
                //    writeText.WriteLine(users_profile[user_number - 1].UserID + "\t" + avgs.Rating_total_avg);


                //    users_calculated_raitings[user_number - 1] = avgs.Rating_total_avg;

                //    ////writing in the difficulty file
                //    fileSystemManager.writeDifficultyToFile(writeTextDiff, avgs);


                //    ////used to insert recommended jobs for a user in the database
                //    elasticMgr.insertRecommenderJob(avgs);


                //    user_number++;

                }

                //total_rating_avg_system /= task.num_users_init;
                //total_similarity_avg_system /= task.num_users_init;
                //total_inaccuracy_system /= task.num_users_init;
                //////writing some more global information
                //fileSystemManager.writeGlobalAveragesInformation(total_rating_avg_system, total_similarity_avg_system, total_inaccuracy_system,
                //    task, writeTextAverages, users_profile, users_calculated_raitings);


                //////closing the three files

                //writeText.Close();
                //writeTextResult.Close();
                //writeTextAverages.Close();
                //writeTextDiff.Close();


                
                ////// Used to insert rating for task performed by workers. (User interface need to be built)
                ////// 
                //////double[,] full_Y = svc.readFullY(Directory.GetCurrentDirectory() + "/files/Y.txt", task);
                //////IElasticSvc e = new ElasticSvcImpl();
                //////e.InsertRatings(job_list, users_profile, full_Y);
                



                //////Console.WriteLine("DONE");

                //////Wait until fisnih
                //////Console.ReadLine();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
