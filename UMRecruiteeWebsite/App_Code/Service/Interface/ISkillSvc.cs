using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Models;

namespace UMRecruiteeWebsite.Service.Interface
{
    public interface ISkillSvc : IService
    {
        List<Skill> selectAllSkill();
        Skill selectSkillById(Skill obj);
        Boolean insertSkill(Skill obj);
        Boolean updateSkill(Skill obj);
        Boolean deleteSkill(Skill obj);
    }
}
