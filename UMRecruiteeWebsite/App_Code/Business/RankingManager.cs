using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Models;
using UMRecruiteeWebsite.Service.Interface;
using UMRecruiteeWebsite.Exceptions.Service;

namespace UMRecruiteeWebsite.Business
{
    public class RankingManager : BusinessManager
    {

        public List<Ranking> selectAllRanking()
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.selectAllRanking();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Ranking selectRankingById(Ranking obj)
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.selectRankingById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertRanking(Ranking obj)
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.insertRanking(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateRanking(Ranking obj)
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.updateRanking(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteRanking(Ranking obj)
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.deleteRanking(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
