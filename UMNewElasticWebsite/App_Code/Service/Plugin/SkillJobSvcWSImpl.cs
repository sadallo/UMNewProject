using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJobService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class SkillJobSvcWSImpl : ISkillJobSvc
    {
       public List<SkillDto> selectAllSkillJob()
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

            try
            {
                List<SkillDto> list = svc.selectAllSkill().ToList<SkillDto>();
                return list;
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public SkillDto selectSkillById(SkillDto obj)
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

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
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
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
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                try
                {
                    SkillDto skill = svc.selectSkillById(obj);

                    if (skill != null)
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
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                try
                {
                    SkillDto skill = svc.selectSkillById(obj);

                    if (skill != null)
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

        //public SkillDto createSkillDTO(System.Guid SkillId, String RankingId)
        //{
        //    using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
        //    {
        //        return svc.createSkillDTO(SkillId, RankingId);
        //    }

        //}
    }
}