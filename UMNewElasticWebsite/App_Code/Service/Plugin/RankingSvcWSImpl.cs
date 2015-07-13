using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class RankingSvcWSImpl : IRankingSvc
    {
        public List<RankingDto> selectAllRanking()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

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
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

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
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
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
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
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
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
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
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                return svc.createRankingDTO(RankingId, RankingName);
            }
        }

    }
}