using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class RecruiteeSvcWSImpl : IRecruiteeSvc
    {
        public List<RecruiteeDto> selectAllRecruitee()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllRecruitee().ToList<RecruiteeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public RecruiteeDto selectRecruiteeById(RecruiteeDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRecruiteeById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {                        
                    return svc.insertRecruitee(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RecruiteeDto rec = svc.selectRecruiteeById(obj);

                    if (rec != null)
                    {
                        return svc.updateRecruitee(obj);
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

        public Boolean deleteRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RecruiteeDto rec = svc.selectRecruiteeById(obj);

                    if (rec != null)
                    {
                        return svc.deleteRecruitee(obj);
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

        public RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                return svc.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue);
            }
            
        }

        public List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRecruiteeBySkillId(SkillId).ToList<RecruiteeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean addSkillToRecruitee(RecruiteeDto obj, String skillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.addSkillToRecruitee(obj.RecruiteeId, skillId);
            }
            catch
            {
                return false;
            }

        }

        public Boolean removeSkillFromRecruitee(RecruiteeDto obj, String skillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.removeSkillFromRecruitee(obj.RecruiteeId, skillId);
            }
            catch
            {
                return false;
            }

        }
    }
}