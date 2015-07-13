using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IRecruiteeSvc : IService
    {
        List<RecruiteeDto> selectAllRecruitee();
        RecruiteeDto selectRecruiteeById(RecruiteeDto obj);
        Boolean insertRecruitee(RecruiteeDto obj);
        Boolean updateRecruitee(RecruiteeDto obj);
        Boolean deleteRecruitee(RecruiteeDto obj);
        RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue);
        List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId);
        Boolean addSkillToRecruitee(RecruiteeDto obj, String SkillId);
        Boolean removeSkillFromRecruitee(RecruiteeDto obj, String skillId);


    }
}