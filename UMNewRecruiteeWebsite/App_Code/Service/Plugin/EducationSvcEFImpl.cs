using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;

namespace UMNewRecruiteeWebsite.Service.Plugin
{
    public class EducationSvcEFImpl : IEducationSvc
    {
        public List<Education> selectAllEducation()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Education), "dbo.SelectAllEducation").Cast<Education>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Education selectEducationById(Education obj)
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {

                return db.Educations.SqlQuery("dbo.SelectEducationById @EducationId='" + obj.EducationId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Boolean insertEducation(Education obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    db.Educations.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateEducation(Education obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    Education edu = db.Educations.SqlQuery("dbo.SelectEducationById @EducationId='" + obj.EducationId.ToString() + "'").Single();

                    if (edu != null)
                    {
                        edu.EducationId = obj.EducationId;
                        edu.EducationDescription = obj.EducationDescription;

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

        public Boolean deleteEducation(Education obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    Education edu = db.Educations.SqlQuery("dbo.SelectEducationById @EducationId='" + obj.EducationId.ToString() + "'").Single();

                    if (edu != null)
                    {
                        db.Educations.Remove(edu);
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
