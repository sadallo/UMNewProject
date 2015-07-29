using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Exceptions.Service;
using UMNewRecruiteeWebsite.DomainDTO;

namespace UMNewRecruiteeWebsite.Business
{
    public class RecruiteeSkillManager : BusinessManager
    {

        public List<RecruiteeSkillDto> selectAllRecruiteeSkill()
        {
            try
            {
                IRecruiteeSkillSvc svc = (IRecruiteeSkillSvc)this.getService(typeof(IRecruiteeSkillSvc).Name);
                return svc.selectAllRecruiteeSkill();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

      
    }
}
