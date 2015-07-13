using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobService;


namespace UMElasticWebsite.Service.Interface
{
    public interface ISkillJobSvc : IService
    {
        List<SkillDto> selectAllSkillJob();
        SkillDto selectSkillById(SkillDto obj);
        Boolean insertSkill(SkillDto obj);
        Boolean updateSkill(SkillDto obj);
        Boolean deleteSkill(SkillDto obj);
        //SkillDto createSkillDTO(System.Guid SkillId, String RankingId);

    }
}