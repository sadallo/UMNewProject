using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewElasticWebsite.DomainDTO;
using NewJobService;
using NewRecruiteeService;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMobile" in both code and config file together.
[ServiceContract]
public interface IServiceMobile
{
    #region Task
    [OperationContract]
    List<TaskDto> selectAllTask();

    [OperationContract]
    TaskDto selectTaskById(Guid TaskId);

    [OperationContract]
    Boolean insertTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription, double? Rating);

    [OperationContract]
    Boolean updateTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription, double? Rating);

    [OperationContract]
    Boolean deleteTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription, double? Rating);

    [OperationContract]
    TaskRatingDTO[] selectRatings();
   
    #endregion

    #region RecommendedJob
    [OperationContract]
    List<RecommendedJobDto> selectAllRecommendedJob();

    [OperationContract]
    RecommendedJobDto selectRecommendedJobByJobIdAndRecruiteeId(Guid JobId, Guid RecruiteeId);

    [OperationContract]
    List<RecommendedJobDto> selectRecommendedJobByRecruiteeId(Guid RecruiteeId);

    [OperationContract]
    Boolean insertRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue);

    [OperationContract]
    Boolean updateRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue);

    [OperationContract]
    Boolean deleteRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue);
    #endregion

    #region Recruitee
    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();
    
    [OperationContract]
    RecruiteeDto selectRecruiteeById(Guid RecruiteeId);

    [OperationContract]
    RecruiteeDto selectRecruiteeByEmail(String RecruiteeId);

    [OperationContract]
    Boolean insertRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    Boolean updateRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    Boolean deleteRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

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
     JobDto selectJobById(Guid JobId);

    [OperationContract]
     Boolean insertJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                       String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
     Boolean updateJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                       String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
     Boolean deleteJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                       String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

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
    NewJobService.SkillDto selectSkillJobById(String SkillId);

    #endregion

    #region SkillRecruitee

    [OperationContract]
    List<NewRecruiteeService.SkillDto> selectAllSkillRecruitee();

    [OperationContract]
    NewRecruiteeService.SkillDto selectSkillRecruiteeById(String SkillId);

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

    #region Age

    [OperationContract]
    List<NewRecruiteeService.AgeDto> selectAllAge();

    [OperationContract]
    NewRecruiteeService.AgeDto selectAgeById(String AgeId);

    #endregion

    #region Education

    [OperationContract]
    List<NewRecruiteeService.EducationDto> selectAllEducation();

    [OperationContract]
    NewRecruiteeService.EducationDto selectEducationById(String EducationId);

    #endregion

    #region Income

    [OperationContract]
    List<NewRecruiteeService.IncomeDto> selectAllIncome();

    [OperationContract]
    NewRecruiteeService.IncomeDto selectIncomeById(String IncomeId);

    #endregion

}

