using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMElasticWebsite.DomainDTO;
using JobService;
using RecruiteeService;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMobile" in both code and config file together.
[ServiceContract]
public interface IServiceMobile
{
    #region Task
    [OperationContract]
    List<TaskDto> selectAllTask();

    [OperationContract]
    TaskDto selectTaskById(System.Guid TaskId);

    [OperationContract]
    Boolean insertTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription);

    [OperationContract]
    Boolean updateTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription);

    [OperationContract]
    Boolean deleteTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription);
    #endregion

    #region Recruitee
    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();
    
    [OperationContract]
    RecruiteeDto selectRecruiteeById(System.Guid RecruiteeId);

    [OperationContract]
    Boolean insertRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue);

    [OperationContract]
    Boolean updateRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue);

    [OperationContract]
    Boolean deleteRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue);

    [OperationContract]
    RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue);

    [OperationContract]
    List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId);

    [OperationContract]
    Boolean addSkillToRecruitee(String RecruiteeId, String SkillId);

    [OperationContract]
    Boolean removeSkillFromRecruitee(String RecruiteeId, String SkillId);    

    #endregion

    #region Job
    [OperationContract]
    List<JobDto> selectAllJob();

    [OperationContract]
     JobDto selectJobById(System.Guid JobId);

    [OperationContract]
     Boolean insertJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                       String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue);

    [OperationContract]
     Boolean updateJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                       String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue);

    [OperationContract]
     Boolean deleteJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                       String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue);

    [OperationContract]
     JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                       String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue);

    [OperationContract]
    List<JobDto> selectJobBySkillId(String SkillId);

    [OperationContract]
    Boolean addSkillToJob(String JobId, String SkillId);

    [OperationContract]
    Boolean removeSkillFromJob(String JobId, String SkillId);    

    #endregion

    #region SkillJob

    [OperationContract]
    List<JobService.SkillDto> selectAllSkillJob();

    [OperationContract]
    JobService.SkillDto selectSkillJobById(String SkillId);

    #endregion

    #region SkillRecruitee

    [OperationContract]
    List<RecruiteeService.SkillDto> selectAllSkillRecruitee();

    [OperationContract]
    RecruiteeService.SkillDto selectSkillRecruiteeById(String SkillId);

    #endregion

    #region Ranking

    [OperationContract]
    List<RankingDto> selectAllRanking();
    
    [OperationContract]
    RankingDto selectRankingById(String RankingId);

    [OperationContract]
    Boolean insertRanking(String RankingId, String RankingName);

    [OperationContract]
    Boolean updateRanking(String RankingId, String RankingName);

    [OperationContract]
    Boolean deleteRanking(String RankingId, String RankingName);

    [OperationContract]
    RankingDto createRankingDTO(String RankingId, String RankingName);
    #endregion


}

