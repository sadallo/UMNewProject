using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Models;
using UMNewJobWebsite.Service.Interface;

namespace UMNewJobWebsite.Service.Plugin
{
    public class EmployerSvcEFImpl : IEmployerSvc
    {
        public List<Employer> selectAllEmployer()
        {
            NewJobBankContext db = new NewJobBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Employer), "dbo.SelectAllEmployer").Cast<Employer>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public Employer selectEmployerById(Employer obj)
        {
            NewJobBankContext db = new NewJobBankContext();
            
            try
            {

                return db.Employers.SqlQuery("dbo.SelectEmployerById @EmployerId='" + obj.EmployerId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertEmployer(Employer obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    db.Employers.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateEmployer(Employer obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {

                    Employer employer = db.Employers.SqlQuery("dbo.SelectEmployerById @EmployerId='" + obj.EmployerId.ToString() + "'").Single();

                    if (employer != null)
                    {
                        employer.EmployerName = obj.EmployerName;
                        

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

        public Boolean deleteEmployer(Employer obj)
        {
            using (NewJobBankContext db = new NewJobBankContext())
            {
                try
                {
                    Employer employer = db.Employers.SqlQuery("dbo.SelectEmployerById @EmployerId='" + obj.EmployerId.ToString() + "'").Single();

                    if (employer != null)
                    {
                        db.Employers.Remove(employer);
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