using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMElasticWebsite.Service.Interface;
using UMElasticWebsite.Exceptions.Service;
using RecruiteeService;

namespace UMElasticWebsite.Business
{
    public class RankingManager : BusinessManager
    {

        public List<RankingDto> selectAllRanking()
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

        public RankingDto selectRankingById(RankingDto obj)
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

        public Boolean insertRanking(RankingDto obj)
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

        public Boolean updateRanking(RankingDto obj)
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

        public Boolean deleteRanking(RankingDto obj)
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

        public RankingDto createRankingDTO(String RankingId, String RankingName)
        {
            try
            {
                IRankingSvc svc = (IRankingSvc)this.getService(typeof(IRankingSvc).Name);
                return svc.createRankingDTO(RankingId, RankingName);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }
    }
       
}
