using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;

namespace UMNewRecruiteeWebsite.Service.Plugin
{
    public class AgeSvcEFImpl : IAgeSvc
    {
        public List<Age> selectAllAge()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Age), "dbo.SelectAllAge").Cast<Age>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Age selectAgeById(Age obj)
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {

                return db.Ages.SqlQuery("dbo.SelectAgeById @AgeId='" + obj.AgeId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Boolean insertAge(Age obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    db.Ages.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateAge(Age obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {

                    Age Age = db.Ages.SqlQuery("dbo.SelectAgeById @AgeId='" + obj.AgeId.ToString() + "'").Single();

                    if (Age != null)
                    {
                        Age.AgeDescription = obj.AgeDescription;

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

        public Boolean deleteAge(Age obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    Age Age = db.Ages.SqlQuery("dbo.SelectAgeById @AgeId='" + obj.AgeId.ToString() + "'").Single();

                    if (Age != null)
                    {
                        db.Ages.Remove(Age);
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
