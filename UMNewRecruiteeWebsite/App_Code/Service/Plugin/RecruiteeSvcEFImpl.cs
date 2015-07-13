using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Business;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;

namespace UMNewRecruiteeWebsite.Service.Plugin
{
    public class RecruiteeSvcEFImpl : IRecruiteeSvc
    {
        public List<Recruitee> selectAllRecruitee()
        {
            RecruiteeBankContext db = new RecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Recruitee), "dbo.SelectAllRecruitee").Cast<Recruitee>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Recruitee selectRecruiteeById(Recruitee obj)
        {
            RecruiteeBankContext db = new RecruiteeBankContext();

            try
            {

                return db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Recruitee> selectRecruiteeBySkillId(String skillId)
        {
            RecruiteeBankContext db = new RecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Recruitee), "dbo.SelectRecruiteeBySkillId @SkillId='" + skillId + "'").Cast<Recruitee>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Boolean insertRecruitee(Recruitee obj)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    db.Recruitees.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        } 

        public Boolean updateRecruitee(Recruitee obj)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {

                    Recruitee recruitee = db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
             
                    if (recruitee != null)
                    {
                        recruitee.RankingId = obj.RankingId;
                        recruitee.RankingValue = obj.RankingValue;


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

        public Boolean deleteRecruitee(Recruitee obj)
        {

            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    Recruitee recruitee = db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();

                    if (recruitee != null)
                    {
                        db.Recruitees.Remove(recruitee);
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


        public Boolean addSkillToRecruitee(Recruitee obj, String skillId)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    Recruitee recruitee = db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
                    Skill skillAdd = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + skillId + "'").Single();

                    if (recruitee != null)
                    {
                        if (skillAdd != null)
                        {
                            recruitee.Skills.Add(skillAdd);
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

        public Boolean removeSkillFromRecruitee(Recruitee obj, String skillId)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    Recruitee recruitee = db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
                    Skill skillRemove = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + skillId + "'").Single();

                    if (recruitee != null)
                    {
                        if (skillRemove != null)
                        {
                            recruitee.Skills.Remove(skillRemove);
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
    }
}
