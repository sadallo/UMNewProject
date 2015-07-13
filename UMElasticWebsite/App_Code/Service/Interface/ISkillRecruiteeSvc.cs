using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruiteeService;


namespace UMElasticWebsite.Service.Interface
{
    public interface ISkillRecruiteeSvc : IService
    {
        List<SkillDto> selectAllSkill();
        SkillDto selectSkillById(SkillDto obj);
        Boolean insertSkill(SkillDto obj);
        Boolean updateSkill(SkillDto obj);
        Boolean deleteSkill(SkillDto obj);
        //SkillRecruiteeDto createSkillRecruiteeDTO(...)
    }
}