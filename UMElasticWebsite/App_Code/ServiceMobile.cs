using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMElasticWebsite.Business;
using UMElasticWebsite.DomainDTO;
using UMElasticWebsite.Models;
using System.ServiceModel.Activation;
using RecruiteeService;
using JobService;

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

    public TaskDto selectTaskById(System.Guid TaskId)
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

    public Boolean insertTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.insertTask(obj);
    }

    public Boolean updateTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.updateTask(obj);
    }

    public Boolean deleteTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription)
    {
        Task obj = Task.createTask(TaskId, JobId, RecruiteeId, TaskDescription);
        TaskManager mgr = new TaskManager();
        return mgr.deleteTask(obj);
    }
    #endregion

    #region Recruitee

    public List<RecruiteeDto> selectAllRecruitee()
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.selectAllRecruitee();
    }

    public RecruiteeDto selectRecruiteeById(System.Guid RecruiteeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = new RecruiteeDto();
        obj.RecruiteeId = RecruiteeId;
        return mgr.selectRecruiteeById(obj);
    }

    public Boolean insertRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue);
        return mgr.insertRecruitee(obj);
    }

    public Boolean updateRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue);
        return mgr.updateRecruitee(obj);
    }

    public Boolean deleteRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        RecruiteeDto obj = mgr.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue);
        return mgr.deleteRecruitee(obj);
    }

    public RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.createRecruiteeDTO(RecruiteeId,RankingId, RankingValue);
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

    public JobDto selectJobById(System.Guid JobId)
    {
        JobManager mgr = new JobManager();
        JobDto obj = new JobDto();
        obj.JobId = JobId;
        return mgr.selectJobById(obj);
    }

    public Boolean insertJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.insertJob(obj);
    }

    public Boolean updateJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.updateJob(obj);
    }

    public Boolean deleteJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        JobManager mgr = new JobManager();
        JobDto obj = mgr.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        return mgr.deleteJob(obj);
    }
    
    public JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
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

    public List<JobService.SkillDto> selectAllSkillJob()
    {
        SkillJobManager mgr = new SkillJobManager();
        return mgr.selectAllSkillJob();
    }

    public JobService.SkillDto selectSkillJobById(String SkillId)
    {
        SkillJobManager mgr = new SkillJobManager();
        JobService.SkillDto obj = new JobService.SkillDto();
        obj.SkillId = SkillId;
        return mgr.selectSkillById(obj);
    }

    #endregion

    #region SkillRecruitee

    public List<RecruiteeService.SkillDto> selectAllSkillRecruitee()
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        return mgr.selectAllSkill();
    }

    public RecruiteeService.SkillDto selectSkillRecruiteeById(String SkillId)
    {
        SkillRecruiteeManager mgr = new SkillRecruiteeManager();
        RecruiteeService.SkillDto obj = new RecruiteeService.SkillDto();
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
}
