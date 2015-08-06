using UMNewElasticWebsite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using UMNewElasticWebsite.Domain;
using System.Threading;

namespace UMNewElasticWebsite.Business
{
    public class DriverFileManager : BusinessManager
    {
        private static string path_fix = HttpContext.Current.Server.MapPath("~/");

        public bool ExecuteMainRoutine()
        {
            try
            {
                ElasticManager elasticMgr = new ElasticManager();


                //Object to Hold Task Parameters
                TaskDimensions task = new TaskDimensions();

                //User number to start proccessing
                int user_number = 1;

                //Load File System Service
                FileSystemManager fileSystemMgr = new FileSystemManager();


                //Method call to get the number of jobs and users from the file Y
                fileSystemMgr.detectSizeOfJobsColumns(task, path_fix + "files/new_Y_53.txt");

                //Method call to get the number of features from the file X, and allocating the X matrix
                double[,] X = fileSystemMgr.getNumberOfFeaturesX(path_fix + "files/X.txt", task);
                fileSystemMgr.readFeaturesX(X, path_fix + "files/X.txt", task);

                //Method call to get the jobs names
                String[] job_list = fileSystemMgr.readJobNames(path_fix + "files/expressions.txt", task);

                //method that return the users profile
                UserProfile[] users_profile = fileSystemMgr.readUserProfile(path_fix + "files/new_user_table_53.txt", task);

                //Creating a variable to write in a File the job recommendations and comparisons
                //Load File Writer
                StreamWriter writeTextResult = fileSystemMgr.getResultStreamWriter();
                StreamWriter writeTextAverages = fileSystemMgr.getAverageStreamWriter();
                StreamWriter writeText = fileSystemMgr.getIdandAvgStreamWriter();
                StreamWriter writeTextDiff = fileSystemMgr.getDifficultyStreamWriter();

                double[] users_calculated_raitings = new double[task.num_users_init];

                double total_rating_avg_system = 0;
                double total_similarity_avg_system = 0;
                double total_inaccuracy_system = 0;

                //Creating a MatLab reference to execute the recommended job script
                MatlabManager matlabMgr = new MatlabManager();

                while (user_number <= task.num_users_init)
                {
                    // job rating file for a user   
                    double[,] my_ratings = new double[task.num_jobs_init, 1];

                    //Now we read R and Y from theirs files (-1 because I will remove the chosen user from the matrixes)
                    double[,] Y = fileSystemMgr.readTrainingY(path_fix + "files/new_Y_53.txt", task, my_ratings, user_number);
                    double[,] R = fileSystemMgr.readTrainingR(path_fix + "files/new_R_53.txt", task, user_number);

                    
                    object[] res = matlabMgr.executeFilter(task, job_list, path_fix + "files", my_ratings, Y, R, X);


                    //Each time creates a  to be used to write the recommended jobs in a file
                    List<TopJobData> mylist = fileSystemMgr.writeValuesToFile(writeTextResult, res, job_list, user_number, X);


                    //Calculate Averages for Jobs for a User
                    DataResult avgs = new DataResult(mylist, mylist.Count, users_profile[user_number - 1]);
                    avgs.AverageForEachJob();
                    fileSystemMgr.writeAveragesToFile(avgs, writeTextAverages, users_profile[user_number - 1]);

                    total_rating_avg_system += avgs.Rating_total_avg;
                    total_similarity_avg_system += avgs.Percentage_total_avg;
                    total_inaccuracy_system += avgs.Self_inaccuracy;
                    //adding the list at the Dictionary for each user

                    //ID and AVGs file
                    writeText.WriteLine(users_profile[user_number - 1].UserID + "\t" + avgs.Rating_total_avg);


                    users_calculated_raitings[user_number - 1] = avgs.Rating_total_avg;

                    //writing in the difficulty file
                    fileSystemMgr.writeDifficultyToFile(writeTextDiff, avgs);


                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        //    ////used to insert recommended jobs for a user in the database
                        bool result = elasticMgr.insertRecommenderJob(avgs);
                    }).Start();


                    user_number++;

                }

                total_rating_avg_system /= task.num_users_init;
                total_similarity_avg_system /= task.num_users_init;
                total_inaccuracy_system /= task.num_users_init;
                //writing some more global information
                fileSystemMgr.writeGlobalAveragesInformation(total_rating_avg_system, total_similarity_avg_system, total_inaccuracy_system,
                     task, writeTextAverages, users_profile, users_calculated_raitings);

                //closing the three files
                writeText.Close();
                writeTextResult.Close();
                writeTextAverages.Close();
                writeTextDiff.Close();

                return true;

                /* 
                 * Used to insert rating for task performed by workers. (User interface need to be built)
                 * 
                double[,] full_Y = svc.readFullY(Directory.GetCurrentDirectory() + "/files/Y.txt", task);
                IElasticSvc e = new ElasticSvcImpl();
                e.InsertRatings(job_list, users_profile, full_Y);
                */
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
