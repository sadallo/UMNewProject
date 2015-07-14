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

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Service : IServiceWCF
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

    public TaskDto selectTaskById(TaskDto dto)
    {
        TaskManager mgr = new TaskManager();
        Task obj = new Task();
        obj.TaskId = dto.TaskId;
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

    public Boolean insertTask(TaskDto dto)
    {
        Task obj = Task.createTask(dto.TaskId, dto.JobId, dto.RecruiteeId, dto.TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.insertTask(obj);
    }

    public Boolean updateTask(TaskDto dto)
    {
        Task obj = Task.createTask(dto.TaskId, dto.JobId, dto.RecruiteeId, dto.TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.updateTask(obj);
    }

    public Boolean deleteTask(TaskDto dto)
    {
        Task obj = Task.createTask(dto.TaskId, dto.JobId, dto.RecruiteeId, dto.TaskDescription);
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

    public RecommendedJobDto selectRecommendedJobByIdAndRecruiteeId(RecommendedJobDto dto)
    {
        RecommendedJobManager mgr = new RecommendedJobManager();
        RecommendedJob obj = new RecommendedJob();
        obj.JobId = dto.JobId;
        obj.RecruiteeId = dto.RecruiteeId;
        obj = mgr.selectRecommendedJobByIdAndRecruiteeId(obj);
        if (obj != null)
        {
            return RecommendedJobDto.createRecommendedJobDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertRecommendedJob(RecommendedJobDto dto)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(dto.JobId, dto.RecruiteeId, (decimal)dto.PredictedRankingValue);
        RecommendedJobManager mgr = new RecommendedJobManager();
        return mgr.insertRecommendedJob(obj);
    }

    public Boolean updateRecommendedJob(RecommendedJobDto dto)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(dto.JobId, dto.RecruiteeId, (decimal)dto.PredictedRankingValue);
        RecommendedJobManager mgr = new RecommendedJobManager();
        return mgr.updateRecommendedJob(obj);
    }

    public Boolean deleteRecommendedJob(RecommendedJobDto dto)
    {
        RecommendedJob obj = RecommendedJob.createRecommendedJob(dto.JobId, dto.RecruiteeId, (decimal)dto.PredictedRankingValue);
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

    public RecruiteeDto selectRecruiteeById(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.selectRecruiteeById(dto);
    }

    public Boolean insertRecruitee(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.insertRecruitee(dto);
    }

    public Boolean updateRecruitee(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.updateRecruitee(dto);
    }

    public Boolean deleteRecruitee(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.deleteRecruitee(dto);
    }

    public RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email, FirstName, LastName, Gender, 
            AgeId, EducationId, IncomeId);
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

    public JobDto selectJobById(JobDto dto)
    {
        JobManager mgr = new JobManager();
        return mgr.selectJobById(dto);
    }

    public Boolean insertJob(JobDto dto)
    {
        JobManager mgr = new JobManager();
        return mgr.insertJob(dto);
    }

    public Boolean updateJob(JobDto dto)
    {
        JobManager mgr = new JobManager();
        return mgr.updateJob(dto);
    }

    public Boolean deleteJob(JobDto dto)
    {
        JobManager mgr = new JobManager();
        return mgr.deleteJob(dto);
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

    public NewJobService.SkillDto selectSkillJobById(NewJobService.SkillDto obj)
    {
        SkillJobManager mgr = new SkillJobManager();
        return mgr.selectSkillById(obj);
    }

    #endregion

    #region SkillRecruitee

    public List<NewRecruiteeService.SkillDto> selectAllSkillRecruitee()
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        return mgr.selectAllSkill();
    }

    public NewRecruiteeService.SkillDto selectSkillRecruiteeById(NewRecruiteeService.SkillDto obj)
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        return mgr.selectSkillById(obj);
    }

    #endregion

    #region Ranking

    public List<RankingDto> selectAllRanking()
    {
        RankingManager mgr = new RankingManager();
        return mgr.selectAllRanking();
    }

    public RankingDto selectRankingById(RankingDto obj)
    {
        RankingManager mgr = new RankingManager();
        return mgr.selectRankingById(obj);
    }

    public Boolean insertRanking(RankingDto obj)
    {
        RankingManager mgr = new RankingManager();
        return mgr.insertRanking(obj);
    }

    public Boolean updateRanking(RankingDto obj)
    {
        RankingManager mgr = new RankingManager();
        return mgr.updateRanking(obj);
    }

    public Boolean deleteRanking(RankingDto obj)
    {
        RankingManager mgr = new RankingManager();
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

    public NewRecruiteeService.AgeDto selectAgeById(NewRecruiteeService.AgeDto obj)
    {
        AgeManager mgr = new AgeManager();
        return mgr.selectAgeById(obj);
    }

    #endregion

    #region Education

    public List<NewRecruiteeService.EducationDto> selectAllEducation()
    {
        EducationManager mgr = new EducationManager();
        return mgr.selectAllEducation();
    }

    public NewRecruiteeService.EducationDto selectEducationById(NewRecruiteeService.EducationDto obj)
    {
        EducationManager mgr = new EducationManager();
        return mgr.selectEducationById(obj);
    }

    #endregion

    #region Income

    public List<NewRecruiteeService.IncomeDto> selectAllIncome()
    {
        IncomeManager mgr = new IncomeManager();
        return mgr.selectAllIncome();
    }

    public NewRecruiteeService.IncomeDto selectIncomeById(NewRecruiteeService.IncomeDto obj)
    {
        IncomeManager mgr = new IncomeManager();
        return mgr.selectIncomeById(obj);
    }

    #endregion



}