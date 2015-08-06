using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Domain;
using UMNewElasticWebsite.DomainDTO;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Business;



namespace UMNewElasticWebsite.Service.Plugin
{
    public class ElasticSvcImpl : IElasticSvc
    {
        public bool insertRecommenderJob(DataResult avgs)
        {
            try
            {
                bool flag = false;
                RecommendedJobManager mgr = new RecommendedJobManager();
                for (int n = 0; n < avgs.Number_top_jobs; n++)
                {
                    RecommendedJob job = new RecommendedJob();
                    job.RecruiteeId = new Guid(avgs.User_profile.UserID);
                    job.JobId = new Guid(avgs.TopJobNames[n]);
                    job.PredictedRankingValue = (decimal)avgs.Mylist.ElementAt(n).PredRecJob;
                    flag = mgr.insertRecommendedJob(job);                    
                }
                return flag;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //To fill Y
        public bool InsertRatings(String[] expressions, UserProfile[] users, double[,] Y)
        {
            try
            {
                TaskManager mgr = new TaskManager();
                List<Task> tasks = mgr.selectAllTask();
                foreach (Task task in tasks)
                {

                    int[,] result = this.GetYIndex(task.JobId.ToString(), task.RecruiteeId.ToString(), expressions, users);
                    task.Rating = (decimal)Y[result[0, 0], result[0, 1]];
                    mgr.updateTask(task);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //This functions receives two strings, the first is the job id, the second is the recruitee id.
        //then, it looks at the expressions array (all jobs ids) to find the index of the given JobID,
        //then, it looks at the users array (all users ids and self ratings) to find the index of the given recruitee id. 
        //then it returns the value of the rating for that job and recruitee on the Y matrix.
        public int[,] GetYIndex(String jobID, String recruiteeID, String[] expressions, UserProfile[] users)
        {
            try
            {
                int column = 0, row = 0;
                for (int i = 0; i < expressions.Length; i++)
                {
                    if ((expressions[i].ToUpper()).Equals(jobID.ToUpper()))
                    {
                        row = i;
                        break;
                    }
                }
                for (int i = 0; i < users.Length; i++)
                {
                    if ((users[i].UserID.ToUpper()).Equals(recruiteeID.ToUpper()))
                    {
                        column = i;
                        break;
                    }
                }
                int[,] result = new int[1, 2];
                result[0, 0] = row;
                result[0, 1] = column;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //getting Y from data base
        public double[,] SelectRatings(String[] expressions, UserProfile[] users)
        {
            try
            {
                double[,] Y = new double[expressions.Length, users.Length];
                TaskManager mgr = new TaskManager();
                TaskRatingDTO[] tasks = mgr.selectRatings();

                foreach (TaskRatingDTO task in tasks)
                {
                    int[,] result = this.GetYIndex(task.JobId.ToString(), task.RecruiteeId.ToString(), expressions, users);
                    Y[result[0, 0], result[0, 1]] = (double)task.Rating;
                }
                return Y;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
