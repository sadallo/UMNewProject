using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruiteeService;
using UMElasticWebsite.Service.Interface;

namespace UMElasticWebsite.Service.Plugin
{
    public class RankingSvcWSImpl : IRankingSvc
    {
        public List<RankingDto> selectAllRanking()
        {
            RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllRanking().ToList<RankingDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public RankingDto selectRankingById(RankingDto obj)
        {
            RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRankingById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertRanking(RankingDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {                        
                    return svc.insertRanking(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateRanking(RankingDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RankingDto rec = svc.selectRankingById(obj);

                    if (rec != null)
                    {
                        return svc.updateRanking(obj);
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

        public Boolean deleteRanking(RankingDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RankingDto rec = svc.selectRankingById(obj);

                    if (rec != null)
                    {
                        return svc.deleteRanking(obj);
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

        public RankingDto createRankingDTO(String RankingId, String RankingName)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                return svc.createRankingDTO(RankingId, RankingName);
            }
        }

    }
}