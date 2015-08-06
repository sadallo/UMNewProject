using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewElasticWebsite.DomainDTO;
using NewRecruiteeService;
using NewJobService;

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

    [OperationContract]
    TaskRatingDTO[] selectRatings();
    
 
    #endregion

    #region RecommendedJob
    [OperationContract]
    List<RecommendedJobDto> selectAllRecommendedJob();

    [OperationContract]
    RecommendedJobDto selectRecommendedJobByJobIdAndRecruiteeId(RecommendedJobDto obj);

    [OperationContract]
    List<RecommendedJobDto> selectRecommendedJobByRecruiteeId(RecommendedJobDto obj);

    [OperationContract]
    Boolean insertRecommendedJob(RecommendedJobDto obj);

    [OperationContract]
    Boolean updateRecommendedJob(RecommendedJobDto obj);

    [OperationContract]
    Boolean deleteRecommendedJob(RecommendedJobDto obj);

    [OperationContract]
    Boolean deleteAllRecommendedJob();
    #endregion

    #region Recruitee

    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();

    [OperationContract]
    RecruiteeDto selectRecruiteeById(RecruiteeDto obj);

    [OperationContract]
    RecruiteeDto selectRecruiteeByEmail(RecruiteeDto obj);

    [OperationContract]
    Boolean insertRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean updateRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean deleteRecruitee(RecruiteeDto obj);

    [OperationContract]
    RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);
    
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
    List<JobDto> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId);

    [OperationContract]
    List<JobDto> selectJobNotDoneByRecruiteeId(String recruiteeId);

    [OperationContract]
    JobDto selectJobById(JobDto obj);

    [OperationContract]
    Boolean insertJob(JobDto obj);

    [OperationContract]
    Boolean updateJob(JobDto obj);

    [OperationContract]
    Boolean deleteJob(JobDto obj);

    [OperationContract]
    JobDto createJobDTO(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
    List<JobDto> selectJobBySkillId(String SkillId);

    [OperationContract]
    Boolean addSkillToJob(String JobId, String SkillId);
    
    [OperationContract]
    Boolean removeSkillFromJob(String JobId, String SkillId);

    #endregion

    #region SkillJob

    [OperationContract]
    List<NewJobService.SkillDto> selectAllSkillJob();

    [OperationContract]
    NewJobService.SkillDto selectSkillJobById(NewJobService.SkillDto obj);

    #endregion

    #region SkillRecruitee

    [OperationContract]
    List<NewRecruiteeService.SkillDto> selectAllSkillRecruitee();

    [OperationContract]
    NewRecruiteeService.SkillDto selectSkillRecruiteeById(NewRecruiteeService.SkillDto obj);

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

    #region Age

    [OperationContract]
    List<NewRecruiteeService.AgeDto> selectAllAge();

    [OperationContract]
    NewRecruiteeService.AgeDto selectAgeById(NewRecruiteeService.AgeDto obj);

    #endregion

    #region Education

    [OperationContract]
    List<NewRecruiteeService.EducationDto> selectAllEducation();

    [OperationContract]
    NewRecruiteeService.EducationDto selectEducationById(NewRecruiteeService.EducationDto obj);

    #endregion

    #region Income

    [OperationContract]
    List<NewRecruiteeService.IncomeDto> selectAllIncome();

    [OperationContract]
    NewRecruiteeService.IncomeDto selectIncomeById(NewRecruiteeService.IncomeDto obj);

    #endregion




}
