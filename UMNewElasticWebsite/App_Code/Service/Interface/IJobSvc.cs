using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJobService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IJobSvc : IService
    {
        List<JobDto> selectAllJob();
        JobDto selectJobById(JobDto obj);
        List<JobDto> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId);
        List<JobDto> selectJobNotDoneByRecruiteeId(String recruiteeId);
        Boolean insertJob(JobDto obj);
        Boolean updateJob(JobDto obj);
        Boolean deleteJob(JobDto obj);
        JobDto createJobDTO(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                            String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);
        List<JobDto> selectJobBySkillId(String SkillId);
        Boolean addSkillToJob(JobDto obj, String skillId);
        Boolean removeSkillFromJob(JobDto obj, String skillId);
        string[] selectExpressionNames();
        double[] selectExpressionDifficulty();

    }
}