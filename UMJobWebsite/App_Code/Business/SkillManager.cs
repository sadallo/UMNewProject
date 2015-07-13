using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMJobWebsite.Models;
using UMJobWebsite.Service.Interface;
using UMJobWebsite.Exceptions.Service;

namespace UMJobWebsite.Business
{
    public class SkillManager : BusinessManager
    {

        public List<Skill> selectAllSkill()
        {
            try
            {
                ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
                return svc.selectAllSkill();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Skill selectSkillById(Skill obj)
        {
            try
            {
                ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
                return svc.selectSkillById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertSkill(Skill obj)
        {
            try
            {
                ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
                return svc.insertSkill(obj);


            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateSkill(Skill obj)
        {
            try
            {
                ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
                return svc.updateSkill(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteSkill(Skill obj)
        {
            try
            {
                ISkillSvc svc = (ISkillSvc)this.getService(typeof(ISkillSvc).Name);
                return svc.deleteSkill(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
