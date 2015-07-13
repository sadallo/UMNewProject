using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruiteeService;
using UMElasticWebsite.Service.Interface;

namespace UMElasticWebsite.Service.Plugin
{
    public class SkillRecruiteeSvcWSImpl : ISkillRecruiteeSvc
    {
        public List<SkillDto> selectAllSkill()
        {
            RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllSkill().ToList<SkillDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SkillDto selectSkillById(SkillDto obj)
        {
            RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectSkillById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertSkill(SkillDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {
                    return svc.insertSkill(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateSkill(SkillDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {
                    SkillDto rec = svc.selectSkillById(obj);

                    if (rec != null)
                    {
                        return svc.updateSkill(obj);
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

        public Boolean deleteSkill(SkillDto obj)
        {
            using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
            {
                try
                {
                    SkillDto rec = svc.selectSkillById(obj);

                    if (rec != null)
                    {
                        return svc.deleteSkill(obj);
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

        //public SkillDto createSkillRecruiteeDTO(...)
        //{
        //    using (RecruiteeService.ServiceWCFClient svc = new RecruiteeService.ServiceWCFClient())
        //    {
        //        return svc.createSkillDTO(...);
        //    }
        //}

    }
}