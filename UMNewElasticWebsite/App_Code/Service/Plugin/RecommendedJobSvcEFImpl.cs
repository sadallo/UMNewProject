using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class RecommendedJobSvcEFImpl : IRecommendedJobSvc
    {
        public List<RecommendedJob> selectAllRecommendedJob()
        {
            NewElasticBankContext db = new NewElasticBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(RecommendedJob), "dbo.SelectAllRecommendedJob").Cast<RecommendedJob>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RecommendedJob selectRecommendedJobByIdAndRecruiteeId(RecommendedJob obj)
        {
            NewElasticBankContext db = new NewElasticBankContext();

            try
            {

                return db.RecommendedJobs.SqlQuery("dbo.SelectRecommendedJobByIdAndRecruiteeId @JobId='" + obj.JobId.ToString() + "' @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertRecommendedJob(RecommendedJob obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {
                    db.RecommendedJobs.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateRecommendedJob(RecommendedJob obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {

                    RecommendedJob rec_job = db.RecommendedJobs.SqlQuery("dbo.SelectRecommendedJobByIdAndRecruiteeId @JobId='" + obj.JobId.ToString() + "' @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();

                    if (rec_job != null)
                    {
                        rec_job.PredictedRankingValue = obj.PredictedRankingValue;

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

        public Boolean deleteRecommendedJob(RecommendedJob obj)
        {
            using (NewElasticBankContext db = new NewElasticBankContext())
            {
                try
                {
                    RecommendedJob rec_job = db.RecommendedJobs.SqlQuery("dbo.SelectRecommendedJobByIdAndRecruiteeId @JobId='" + obj.JobId.ToString() + "' @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();

                    if (rec_job != null)
                    {
                        db.RecommendedJobs.Remove(rec_job);
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