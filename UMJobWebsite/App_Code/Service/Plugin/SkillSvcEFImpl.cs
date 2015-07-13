using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;
using UMJobWebsite.Service.Interface;

namespace UMJobWebsite.Service.Plugin
{
    public class SkillSvcEFImpl : ISkillSvc
    {
        public List<Skill> selectAllSkill()
        {
            JobBankContext db = new JobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Skill), "dbo.SelectAllSkill").Cast<Skill>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Skill selectSkillById(Skill obj)
        {
            JobBankContext db = new JobBankContext();

            try
            {
                
                return db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + obj.SkillId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertSkill(Skill obj)
        {
            using (JobBankContext db = new JobBankContext())
            {
                try
                {
                    db.Skills.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateSkill(Skill obj)
        {
            using (JobBankContext db = new JobBankContext())
            {
                try
                {

                    Skill skill = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + obj.SkillId.ToString() + "'").Single();

                    if (skill != null)
                    {
                        skill.SkillName = obj.SkillName;
                        skill.SkillDescription = obj.SkillDescription;

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

        public Boolean deleteSkill(Skill obj)
        {
            using (JobBankContext db = new JobBankContext())
            {
                try
                {
                    Skill skill = db.Skills.SqlQuery("dbo.SelectSkillById @SkillId='" + obj.SkillId.ToString() + "'").Single();

                    if (skill != null)
                    {
                        db.Skills.Remove(skill);
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