﻿using System;
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
        public Guid[] selectRecruiteeNames()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();
            
            try
            {
                //return ((from a in db.Recruitees
                //         orderby a.RecruiteeId
                //         select a.RecruiteeId).ToArray());

                // Select Recruitee Ids using any query on SelectRecruiteeSpecial stored procedure
                //List<Recruitee> list_recruitees = db.Database.SqlQuery(typeof(Recruitee), "dbo.SelectRecruiteeSpecial").Cast<Recruitee>().ToList();
                //List<Guid> list_id = new List<Guid>();
                //foreach (Recruitee rec in list_recruitees)
                //{
                //    list_id.Add(rec.RecruiteeId);
                //}
                //return list_id.ToArray();
                List<Guid> list_id = db.Database.SqlQuery(typeof(Guid), "dbo.SelectRecruiteeSpecial").Cast<Guid>().ToList();
                return list_id.ToArray();

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Recruitee> selectAllRecruitee()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

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
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {

                return db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Recruitee selectRecruiteeByEmail(Recruitee obj)
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {

                return db.Recruitees.SqlQuery("dbo.SelectRecruiteeByEmail @Email='" + obj.Email.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Recruitee> selectRecruiteeBySkillId(String skillId)
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

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
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
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
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {

                    Recruitee recruitee = db.Recruitees.SqlQuery("dbo.SelectRecruiteeById @RecruiteeId='" + obj.RecruiteeId.ToString() + "'").Single();
                   
                    if (recruitee != null)
                    {
                        recruitee.RankingId = obj.RankingId;
                        recruitee.RankingValue = obj.RankingValue;
                        recruitee.Email = obj.Email;
                        recruitee.FirstName = obj.FirstName;
                        recruitee.LastName = obj.LastName;
                        recruitee.Gender = obj.Gender;
                        recruitee.AgeId = obj.AgeId;
                        recruitee.EducationId = obj.EducationId;
                        recruitee.IncomeId = obj.IncomeId;


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

            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
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
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
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
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
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
