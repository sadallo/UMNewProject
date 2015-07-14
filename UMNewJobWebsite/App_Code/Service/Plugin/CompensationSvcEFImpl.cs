using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Service.Interface;
using UMNewJobWebsite.Models;

namespace UMNewJobWebsite.Service.Plugin
{
    public class CompensationSvcEFImpl : ICompensationSvc
    {
        public List<Compensation> selectAllCompensation()
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Compensation), "dbo.SelectAllCompensation").Cast<Compensation>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Compensation selectCompensationById(Compensation obj)
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {

                return db.Compensations.SqlQuery("dbo.SelectCompensationById @CompensationId='" + obj.CompensationId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertCompensation(Compensation obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    db.Compensations.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateCompensation(Compensation obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {

                    Compensation compensation = db.Compensations.SqlQuery("dbo.SelectCompensationById @CompensationId='" + obj.CompensationId.ToString() + "'").Single();

                    if (compensation != null)
                    {
                        compensation.CompensationType = obj.CompensationType;
                        compensation.CompensationDescription = obj.CompensationDescription;

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

        public Boolean deleteCompensation(Compensation obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    Compensation compensation = db.Compensations.SqlQuery("dbo.SelectCompensationById @CompensationId='" + obj.CompensationId.ToString() + "'").Single();

                    if (compensation != null)
                    {
                        db.Compensations.Remove(compensation);
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