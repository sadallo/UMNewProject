using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class TaskSvcEFImpl : ITaskSvc
    {
        public List<Task> selectAllTask()
        {
            ElasticBankContext db = new ElasticBankContext();

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
            ElasticBankContext db = new ElasticBankContext();

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
            using (ElasticBankContext db = new ElasticBankContext())
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
            using (ElasticBankContext db = new ElasticBankContext())
            {
                try
                {

                    Task task = db.Tasks.SqlQuery("dbo.SelectTaskById @TaskId='" + obj.TaskId.ToString() + "'").Single();

                    if (task != null)
                    {
                        task.JobId = obj.JobId;
                        task.RecruiteeId = obj.RecruiteeId;
                        task.TaskDescription = obj.TaskDescription;

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
            using (ElasticBankContext db = new ElasticBankContext())
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