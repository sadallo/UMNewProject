using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;

namespace UMNewRecruiteeWebsite.Service.Plugin
{
    public class IncomeSvcEFImpl : IIncomeSvc
    {
        public List<Income> selectAllIncome()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Income), "dbo.SelectAllIncome").Cast<Income>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Income selectIncomeById(Income obj)
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {

                return db.Incomes.SqlQuery("dbo.SelectIncomeById @IncomeId='" + obj.IncomeId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Boolean insertIncome(Income obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    db.Incomes.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateIncome(Income obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {

                    Income Income = db.Incomes.SqlQuery("dbo.SelectIncomeById @IncomeId='" + obj.IncomeId.ToString() + "'").Single();

                    if (Income != null)
                    {
                        Income.IncomeDescription = obj.IncomeDescription;

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

        public Boolean deleteIncome(Income obj)
        {
            using (NewRecruiteeBankContext db = new NewRecruiteeBankContext())
            {
                try
                {
                    Income Income = db.Incomes.SqlQuery("dbo.SelectIncomeById @IncomeId='" + obj.IncomeId.ToString() + "'").Single();

                    if (Income != null)
                    {
                        db.Incomes.Remove(Income);
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
