using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Models;
using UMNewJobWebsite.Service.Interface;

namespace UMNewJobWebsite.Service.Plugin
{
    public class JobSvcEFImpl : IJobSvc
    {
        public Guid[] selectExpressionNames()
        {
            NewJobBankContext db = new NewJobBankContext();
            return ((from a in db.Jobs
                     orderby a.JobDescription
                     select a.JobId).ToArray());
        }

        public double[] selectExpressionDifficulty()
        {
            NewJobBankContext db = new NewJobBankContext();
            decimal[] res = ((from a in db.Jobs
                              orderby a.JobDescription
                              select a.JobExperienceLevel).ToArray());

            double[] arr = new double[res.Length];
            for(int i=0; i<res.Length; i++)
            {
                arr[i] = (double)res[i];
            }

            return arr;
        }

   
        public List<Job> selectAllJob()
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Job), "dbo.SelectAllJob").Cast<Job>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Job selectJobById(Job obj)
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {               
                return db.Jobs.SqlQuery("dbo.SelectJobById @JobId='" + obj.JobId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Job> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId)
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Job), "dbo.SelectJobNotDoneByRecruiteeIdRecommendation @RecruiteeId='" + recruiteeId + "'").Cast<Job>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Job> selectJobNotDoneByRecruiteeId(String recruiteeId)
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Job), "dbo.selectJobNotDoneByRecruiteeId @RecruiteeId='" + recruiteeId + "'").Cast<Job>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertJob(Job obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    db.Jobs.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateJob(Job obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {

                    Job job = db.Jobs.SqlQuery("dbo.SelectJobById @JobId='" + obj.JobId.ToString() + "'").Single();

                    if (job != null)
                    {
                        job.JobName = obj.JobName;
                        job.CompensationId = obj.CompensationId;
                        job.EmployerId = obj.EmployerId;
                        job.JobDescription = obj.JobDescription;
                        job.JobQuota = obj.JobQuota;
                        job.JobExperienceLevel = obj.JobExperienceLevel;
                        job.JobCompensationValue = obj.JobCompensationValue;

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

        public Boolean deleteJob(Job obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    Job job = db.Jobs.SqlQuery("dbo.SelectJobById @JobId='" + obj.JobId.ToString() + "'").Single();

                    if (job != null)
                    {
                        db.Jobs.Remove(job);
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

        public Boolean addSkillToJob(Job obj, String skillId)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    Job Job = db.Jobs.SqlQuery("dbo.SelectJobById @JobId='" + obj.JobId.ToString() + "'").Single();
                    Skill skillAdd = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + skillId + "'").Single();

                    if (Job != null)
                    {
                        if (skillAdd != null)
                        {
                            Job.Skills.Add(skillAdd);
                        }

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

        public Boolean removeSkillFromJob(Job obj, String skillId)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    Job Job = db.Jobs.SqlQuery("dbo.SelectJobById @JobId='" + obj.JobId.ToString() + "'").Single();
                    Skill skillRemove = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + skillId + "'").Single();

                    if (Job != null)
                    {
                        if (skillRemove != null)
                        {
                            Job.Skills.Remove(skillRemove);
                        }

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

        public List<Job> selectJobBySkillId(String skillId)
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Job), "dbo.SelectJobBySkillId @SkillId='" + skillId + "'").Cast<Job>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }





    }
}