using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Models;
using UMRecruiteeWebsite.Service.Interface;

namespace UMRecruiteeWebsite.Service.Plugin
{
    public class RankingSvcEFImpl : IRankingSvc
    {
        public List<Ranking> selectAllRanking()
        {
            RecruiteeBankContext db = new RecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(Ranking), "dbo.SelectAllRanking").Cast<Ranking>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Ranking selectRankingById(Ranking obj)
        {
            RecruiteeBankContext db = new RecruiteeBankContext();

            try
            {

                return db.Rankings.SqlQuery("dbo.SelectRankingById @RankingId='" + obj.RankingId.ToString() + "'").Single();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Boolean insertRanking(Ranking obj)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    db.Rankings.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean updateRanking(Ranking obj)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {

                    Ranking ranking = db.Rankings.SqlQuery("dbo.SelectRankingById @RankingId='" + obj.RankingId.ToString() + "'").Single();

                    if (ranking != null)
                    {
                        ranking.RankingName = obj.RankingName;

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

        public Boolean deleteRanking(Ranking obj)
        {
            using (RecruiteeBankContext db = new RecruiteeBankContext())
            {
                try
                {
                    Ranking ranking = db.Rankings.SqlQuery("dbo.SelectRankingById @RankingId='" + obj.RankingId.ToString() + "'").Single();

                    if (ranking != null)
                    {
                        db.Rankings.Remove(ranking);
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
