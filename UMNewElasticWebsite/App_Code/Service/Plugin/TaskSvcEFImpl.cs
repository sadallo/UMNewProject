using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.DomainDTO;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class TaskSvcEFImpl : ITaskSvc
    {

        public TaskRatingDTO[] selectRatings()
        {
            NewElasticBankContext db = new NewElasticBankContext();
            return (from a in db.Tasks
                      select new TaskRatingDTO
                      { JobId = a.JobId, RecruiteeId = a.RecruiteeId, Rating = (double?)a.Rating }).ToArray<TaskRatingDTO>();
                      
        }

        public List<Task> selectAllTask()
        {
            NewElasticBankContext db = new NewElasticBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Task), "dbo.SelectAllTask").Cast<Task>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task selectTaskById(Task obj)
        {
            NewElasticBankContext db = new NewElasticBankContext();

            try
            {

                return db.Tasks.SqlQuery("dbo.SelectTaskById @TaskId='" + obj.TaskId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertTask(Task obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {
                    db.Tasks.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateTask(Task obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {

                    Task task = db.Tasks.SqlQuery("dbo.SelectTaskById @TaskId='" + obj.TaskId.ToString() + "'").Single();

                    if (task != null)
                    {
                        task.JobId = obj.JobId;
                        task.RecruiteeId = obj.RecruiteeId;
                        task.TaskDescription = obj.TaskDescription;
                        task.Rating = obj.Rating;

                        #region Database Submission with Rollback

                        try
                        {
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                        #endregion
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean deleteTask(Task obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {
                    Task task = db.Tasks.SqlQuery("dbo.SelectTaskById @TaskId='" + obj.TaskId.ToString() + "'").Single();

                    if (task != null)
                    {
                        db.Tasks.Remove(task);
                        #region Database Submission

                        try
                        {
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }

                        #endregion
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}