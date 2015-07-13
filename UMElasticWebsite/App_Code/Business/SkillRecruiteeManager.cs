using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMElasticWebsite.Service.Interface;
using UMElasticWebsite.Exceptions.Service;
using RecruiteeService;

namespace UMElasticWebsite.Business
{
    public class SkillRecruiteeManager : BusinessManager
    {

        public List<SkillDto> selectAllSkill()
        {
            try
            {
                ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
                return svc.selectAllSkill();
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
                ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
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
                ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
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
                ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
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
                ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
                return svc.deleteSkill(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        //public SkillDto createSkillRecruiteeDTO(System.Guid SkillId, String SkillId)
        //{
        //    try
        //    {
        //        ISkillRecruiteeSvc svc = (ISkillRecruiteeSvc)this.getService(typeof(ISkillRecruiteeSvc).Name);
        //        return svc.createSkillDTO(SkillId, SkillId);
        //    }
        //    catch (ServiceLoadException ex)
        //    {
        //        return null;
        //    }
        //}
    }
       
}
