using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewElasticWebsite.Business;
using UMNewElasticWebsite.DomainDTO;
using UMNewElasticWebsite.Models;
using System.ServiceModel.Activation;
using NewRecruiteeService;
using NewJobService;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMobile" in code, svc and config file together.
public class ServiceMobile : IServiceMobile
{
    #region Task

    public List<TaskDto> selectAllTask()
    {
        TaskManager mgr = new TaskManager();
        List<Task> taskList = mgr.selectAllTask();
        List<TaskDto> dtoList = new List<TaskDto>();

        foreach (Task task in taskList)
        {
            dtoList.Add(TaskDto.createTaskDTO(task));
        }

        return dtoList;
    }

    public TaskDto selectTaskById(Guid TaskId)
    {
        TaskManager mgr = new TaskManager();
        Task obj = new Task();
        obj.TaskId = TaskId;
        obj = mgr.selectTaskById(obj);
        if (obj != null)
        {
            return TaskDto.createTaskDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.insertTask(obj);
    }

    public Boolean updateTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.updateTask(obj);
    }

    public Boolean deleteTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.deleteTask(obj);
    }
    #endregion

    #region RecommendedJob

    public List<RecommendedJobDto> selectAllRecommendedJob()
    {
        RecommendedJobManager mgr = new RecommendedJobManager();
        List<RecommendedJob> taskList = mgr.selectAllRecommendedJob();
        List<RecommendedJobDto> dtoList = new List<RecommendedJobDto>();

        foreach (RecommendedJob task in taskList)
        {
            dtoList.Add(RecommendedJobDto.createRecommendedJobDTO(task));
        }

        return dtoList;
    }

    public RecommendedJobDto selectRecommendedJobByJobIdAndRecruiteeId(Guid JobId, Guid RecruiteeId)
    {
        RecommendedJobManager mgr = new RecommendedJobManager();
        RecommendedJob obj = new RecommendedJob();
        obj.JobId = JobId;
        obj.RecruiteeId = RecruiteeId;
        obj = mgr.selectRecommendedJobByJobIdAndRecruiteeId(obj);
        if (obj != null)
        {
            return RecommendedJobDto.createRecommendedJobDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(JobId, RecruiteeId, (decimal)PredictedRankingValue);
        RecommendedJobManager mgr = new RecommendedJobManager();
        return mgr.insertRecommendedJob(obj);
    }

    public Boolean updateRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(JobId, RecruiteeId, (decimal)PredictedRankingValue);
        RecommendedJobManager mgr = new RecommendedJobManager();
        return mgr.updateRecommendedJob(obj);
    }

    public Boolean deleteRecommendedJob(Guid JobId, Guid RecruiteeId, double PredictedRankingValue)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(JobId, RecruiteeId, (decimal)PredictedRankingValue);
        RecommendedJobManager mgr = new RecommendedJobManager();
        return mgr.deleteRecommendedJob(obj);
    }
    #endregion

    #region Recruitee

    public List<RecruiteeDto> selectAllRecruitee()
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.selectAllRecruitee();
    }

    public RecruiteeDto selectRecruiteeById(Guid RecruiteeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = new RecruiteeDto();
        obj.RecruiteeId = RecruiteeId;
        return mgr.selectRecruiteeById(obj);
    }

    public RecruiteeDto selectRecruiteeByEmail(String Email)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = new RecruiteeDto();
        obj.Email = Email;
        return mgr.selectRecruiteeByEmail(obj);
    }

    public Boolean insertRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
        return mgr.insertRecruitee(obj);
    }

    public Boolean updateRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
        return mgr.updateRecruitee(obj);
    }

    public Boolean deleteRecruitee(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
        return mgr.deleteRecruitee(obj);
    }

    public RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
    }

    public List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.selectRecruiteeBySkillId(SkillId);
    }

    public Boolean addSkillToRecruitee(String RecruiteeId, String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = new RecruiteeDto();
        obj.RecruiteeId = new Guid(RecruiteeId);
        return mgr.addSkillToRecruitee(obj, SkillId);
    }

    public Boolean removeSkillFromRecruitee(String RecruiteeId, String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = new RecruiteeDto();
        obj.RecruiteeId = new Guid(RecruiteeId);
        return mgr.removeSkillFromRecruitee(obj, SkillId);
    }

    #endregion

    #region Job

    public List<JobDto> selectAllJob()
    {
        JobManager mgr = new JobManager();
        return mgr.selectAllJob();
    }

    public JobDto selectJobById(Guid JobId)
    {
        JobManager mgr = new JobManager();
        JobDto obj = new JobDto();
        obj.JobId = JobId;
        return mgr.selectJobById(obj);
    }

    public Boolean insertJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.insertJob(obj);
    }

    public Boolean updateJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.updateJob(obj);
    }

    public Boolean deleteJob(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.deleteJob(obj);
    }
    
    public JobDto createJobDTO(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        return mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
    }

    public List<JobDto> selectJobBySkillId(String SkillId)
    {
        JobManager mgr = new JobManager();
        return mgr.selectJobBySkillId(SkillId);
    }

    public Boolean addSkillToJob(String JobId, String SkillId)
    {
        JobManager mgr = new JobManager();
        JobDto obj = new JobDto();
        obj.JobId = new Guid(JobId);
        return mgr.addSkillToJob(obj, SkillId);
    }

    public Boolean removeSkillFromJob(String JobId, String SkillId)
    {
        JobManager mgr = new JobManager();
        JobDto obj = new JobDto();
        obj.JobId = new Guid(JobId);
        return mgr.removeSkillFromJob(obj, SkillId);
    }

    #endregion

    #region SkillJob

    public List<NewJobService.SkillDto> selectAllSkillJob()
    {
        SkillJobManager mgr = new SkillJobManager();
        return mgr.selectAllSkillJob();
    }

    public NewJobService.SkillDto selectSkillJobById(String SkillId)
    {
        SkillJobManager mgr = new SkillJobManager();
        NewJobService.SkillDto obj = new NewJobService.SkillDto();
        obj.SkillId = SkillId;
        return mgr.selectSkillById(obj);
    }

    #endregion

    #region SkillRecruitee

    public List<NewRecruiteeService.SkillDto> selectAllSkillRecruitee()
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        return mgr.selectAllSkill();
    }

    public NewRecruiteeService.SkillDto selectSkillRecruiteeById(String SkillId)
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        NewRecruiteeService.SkillDto obj = new NewRecruiteeService.SkillDto();
        obj.SkillId = SkillId;
        return mgr.selectSkillById(obj);
    }

    #endregion

    #region Ranking

    public List<RankingDto> selectAllRanking()
    {
        RankingManager mgr = new RankingManager();
        return mgr.selectAllRanking();
    }

    public RankingDto selectRankingById(String RankingId)
    {
        RankingManager mgr = new RankingManager();
        RankingDto obj = new RankingDto();
        obj.RankingId = RankingId;
        return mgr.selectRankingById(obj);
    }

    public Boolean insertRanking(String RankingId, String RankingName)
    {
        RankingManager mgr = new RankingManager();
        RankingDto obj = mgr.createRankingDTO(RankingId, RankingName);
        return mgr.insertRanking(obj);
    }

    public Boolean updateRanking(String RankingId, String RankingName)
    {
        RankingManager mgr = new RankingManager();
        RankingDto obj = mgr.createRankingDTO(RankingId, RankingName);
        return mgr.updateRanking(obj);
    }

    public Boolean deleteRanking(String RankingId, String RankingName)
    {
        RankingManager mgr = new RankingManager();
        RankingDto obj = mgr.createRankingDTO(RankingId, RankingName);
        return mgr.deleteRanking(obj);
    }

    public RankingDto createRankingDTO(String RankingId, String RankingName)
    {
        RankingManager mgr = new RankingManager();
        return mgr.createRankingDTO(RankingId, RankingName);
    }

    #endregion

    #region Age

    public List<NewRecruiteeService.AgeDto> selectAllAge()
    {
        AgeManager mgr = new AgeManager();
        return mgr.selectAllAge();
    }

    public NewRecruiteeService.AgeDto selectAgeById(String AgeId)
    {
        AgeManager mgr = new AgeManager();
        NewRecruiteeService.AgeDto obj = new NewRecruiteeService.AgeDto();
        obj.AgeId = AgeId;
        return mgr.selectAgeById(obj);
    }

    #endregion

    #region Education

    public List<NewRecruiteeService.EducationDto> selectAllEducation()
    {
        EducationManager mgr = new EducationManager();
        return mgr.selectAllEducation();
    }

    public NewRecruiteeService.EducationDto selectEducationById(String EducationId)
    {
        EducationManager mgr = new EducationManager();
        NewRecruiteeService.EducationDto obj = new NewRecruiteeService.EducationDto();
        obj.EducationId = EducationId;
        return mgr.selectEducationById(obj);
    }

    #endregion

    #region Income

    public List<NewRecruiteeService.IncomeDto> selectAllIncome()
    {
        IncomeManager mgr = new IncomeManager();
        return mgr.selectAllIncome();
    }

    public NewRecruiteeService.IncomeDto selectIncomeById(String IncomeId)
    {
        IncomeManager mgr = new IncomeManager();
        NewRecruiteeService.IncomeDto obj = new NewRecruiteeService.IncomeDto();
        obj.IncomeId = IncomeId;
        return mgr.selectIncomeById(obj);
    }

    #endregion
}
