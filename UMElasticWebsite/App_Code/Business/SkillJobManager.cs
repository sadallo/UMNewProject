using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMElasticWebsite.Service.Interface;
using UMElasticWebsite.Exceptions.Service;
using JobService;

namespace UMElasticWebsite.Business
{
    public class SkillJobManager : BusinessManager
    {

        public List<SkillDto> selectAllSkillJob()
        {
            try
            {
                ISkillJobSvc svc = (ISkillJobSvc)this.getService(typeof(ISkillJobSvc).Name);
                return svc.selectAllSkillJob();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public SkillDto selectSkillById(SkillDto obj)
        {
            try
            {
                ISkillJobSvc svc = (ISkillJobSvc)this.getService(typeof(ISkillJobSvc).Name);
                return svc.selectSkillById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertSkill(SkillDto obj)
        {
            try
            {
                ISkillJobSvc svc = (ISkillJobSvc)this.getService(typeof(ISkillJobSvc).Name);
                return svc.insertSkill(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateSkill(SkillDto obj)
        {
            try
            {
                ISkillJobSvc svc = (ISkillJobSvc)this.getService(typeof(ISkillJobSvc).Name);
                return svc.updateSkill(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteSkill(SkillDto obj)
        {
            try
            {
                ISkillJobSvc svc = (ISkillJobSvc)this.getService(typeof(ISkillJobSvc).Name);
                return svc.deleteSkill(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        //public SkillDto createSkillDTO(System.Guid SkillId, String RankingId)
        //{
        //    try
        //    {
        //        ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
        //        return svc.createSkillDTO(SkillId, RankingId); 
        //    }
        //    catch (ServiceLoadException ex)
        //    {
        //        return null;
        //    }
        //}


    }
       
}
