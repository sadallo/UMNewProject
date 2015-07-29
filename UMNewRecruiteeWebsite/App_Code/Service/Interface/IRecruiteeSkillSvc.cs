using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.DomainDTO;

namespace UMNewRecruiteeWebsite.Service.Interface

{
    public interface IRecruiteeSkillSvc : IService
    {
        List<RecruiteeSkillDto> selectAllRecruiteeSkill();
    }
}
