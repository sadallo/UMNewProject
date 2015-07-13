using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMElasticWebsite.DomainDTO;
using RecruiteeService;
using JobService;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IServiceWCF
{	
    #region Task
 
    [OperationContract]
    List<TaskDto> selectAllTask();

    [OperationContract]
    TaskDto selectTaskById(TaskDto obj);

    [OperationContract]
    Boolean insertTask(TaskDto obj);

    [OperationContract]
    Boolean updateTask(TaskDto obj);

    [OperationContract]
    Boolean deleteTask(TaskDto obj);
 
    #endregion

    #region Recruitee

    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();

    [OperationContract]
    RecruiteeDto selectRecruiteeById(RecruiteeDto obj);

    [OperationContract]
    Boolean insertRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean updateRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean deleteRecruitee(RecruiteeDto obj);

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
    JobDto selectJobById(JobDto obj);

    [OperationContract]
    Boolean insertJob(JobDto obj);

    [OperationContract]
    Boolean updateJob(JobDto obj);

    [OperationContract]
    Boolean deleteJob(JobDto obj);

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
    JobService.SkillDto selectSkillJobById(JobService.SkillDto obj);

    #endregion

    #region SkillRecruitee

    [OperationContract]
    List<RecruiteeService.SkillDto> selectAllSkillRecruitee();

    [OperationContract]
    RecruiteeService.SkillDto selectSkillRecruiteeById(RecruiteeService.SkillDto obj);

    #endregion

    #region Ranking

    [OperationContract]
    List<RankingDto> selectAllRanking();

    [OperationContract]
    RankingDto selectRankingById(RankingDto obj);

    [OperationContract]
    Boolean insertRanking(RankingDto obj);

    [OperationContract]
    Boolean updateRanking(RankingDto obj);

    [OperationContract]
    Boolean deleteRanking(RankingDto obj);

    [OperationContract]
    RankingDto createRankingDTO(String RankingId, String RankingName);

    #endregion




}
