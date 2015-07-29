using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewJobWebsite.Business;
using UMNewJobWebsite.DomainDTO;
using UMNewJobWebsite.Models;
using System.ServiceModel.Activation;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Service : IServiceWCF
{
    #region Category

    public List<CategoryDto> selectAllCategory()
    {
        CategoryManager mgr = new CategoryManager();
        List<Category> catList = mgr.selectAllCategory();
        List<CategoryDto> dtoList = new List<CategoryDto>();

        foreach (Category cat in catList)
        {
            dtoList.Add(CategoryDto.createCategoryDTO(cat));
        }

        return dtoList;
    }

    public CategoryDto selectCategoryById(CategoryDto dto)
    {
        CategoryManager mgr = new CategoryManager();
        Category obj = new Category();
        obj.CategoryId = dto.CategoryId;
        obj = mgr.selectCategoryById(obj);
        if (obj != null)
        {
            return CategoryDto.createCategoryDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertCategory(CategoryDto dto)
    {
        Category obj = Category.createCategory(dto.CategoryId, dto.CategoryName, dto.CategoryDescription);
        CategoryManager mgr = new CategoryManager();
        return mgr.insertCategory(obj);
    }

    public Boolean updateCategory(CategoryDto dto)
    {
        Category obj = Category.createCategory(dto.CategoryId, dto.CategoryName, dto.CategoryDescription);
        CategoryManager mgr = new CategoryManager();
        return mgr.updateCategory(obj);
    }

    public Boolean deleteCategory(CategoryDto dto)
    {
        Category obj = Category.createCategory(dto.CategoryId, dto.CategoryName, dto.CategoryDescription);
        CategoryManager mgr = new CategoryManager();
        return mgr.deleteCategory(obj);
    }
    #endregion

    #region Compensation
    public List<CompensationDto> selectAllCompensation()
    {
        CompensationManager mgr = new CompensationManager();
        List<Compensation> compList = mgr.selectAllCompensation();
        List<CompensationDto> dtoList = new List<CompensationDto>();

        foreach (Compensation comp in compList)
        {
            dtoList.Add(CompensationDto.createCompensationDTO(comp));
        }

        return dtoList;
    }

    public CompensationDto selectCompensationById(CompensationDto dto)
    {
        CompensationManager mgr = new CompensationManager();
        Compensation obj = new Compensation();
        obj.CompensationId = dto.CompensationId;
        obj = mgr.selectCompensationById(obj);
        if (obj != null)
        {
            return CompensationDto.createCompensationDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertCompensation(CompensationDto dto)
    {
        Compensation obj = Compensation.createCompensation(dto.CompensationId, dto.CompensationType, dto.CompensationDescription);
        CompensationManager mgr = new CompensationManager();
        return mgr.insertCompensation(obj);
    }

    public Boolean updateCompensation(CompensationDto dto)
    {
        Compensation obj = Compensation.createCompensation(dto.CompensationId, dto.CompensationType, dto.CompensationDescription);
        CompensationManager mgr = new CompensationManager();
        return mgr.updateCompensation(obj);
    }

    public Boolean deleteCompensation(CompensationDto dto)
    {
        Compensation obj = Compensation.createCompensation(dto.CompensationId, dto.CompensationType, dto.CompensationDescription);
        CompensationManager mgr = new CompensationManager();
        return mgr.deleteCompensation(obj);
    }
    #endregion

    #region Employer

    public List<EmployerDto> selectAllEmployer()
    {
        EmployerManager mgr = new EmployerManager();
        List<Employer> employerList = mgr.selectAllEmployer();
        List<EmployerDto> dtoList = new List<EmployerDto>();

        foreach (Employer employer in employerList)
        {
            dtoList.Add(EmployerDto.createEmployerDTO(employer));
        }

        return dtoList;
    }

    public EmployerDto selectEmployerById(EmployerDto dto)
    {
        EmployerManager mgr = new EmployerManager();
        Employer obj = new Employer();
        obj.EmployerId = dto.EmployerId;
        obj = mgr.selectEmployerById(obj);
        if (obj != null)
        {
            return EmployerDto.createEmployerDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertEmployer(EmployerDto dto)
    {
        Employer obj = Employer.createEmployer(dto.EmployerId, dto.EmployerName);
        EmployerManager mgr = new EmployerManager();
        return mgr.insertEmployer(obj);
    }

    public Boolean updateEmployer(EmployerDto dto)
    {
        Employer obj = Employer.createEmployer(dto.EmployerId, dto.EmployerName);
        EmployerManager mgr = new EmployerManager();
        return mgr.updateEmployer(obj);
    }

    public Boolean deleteEmployer(EmployerDto dto)
    {
        Employer obj = Employer.createEmployer(dto.EmployerId, dto.EmployerName);
        EmployerManager mgr = new EmployerManager();
        return mgr.deleteEmployer(obj);
    }

    #endregion
    
    #region Job

    public List<JobDto> selectAllJob()
    {
        JobManager mgr = new JobManager();
        List<Job> jobList = mgr.selectAllJob();
        List<JobDto> dtoList = new List<JobDto>();

        foreach (Job job in jobList)
        {
            dtoList.Add(JobDto.createJobDTO(job));
        }

        return dtoList;
    }

    
    public List<JobDto> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId)
    {
        JobManager mgr = new JobManager();
        List<Job> jobList = mgr.selectJobNotDoneByRecruiteeIdRecommendation(recruiteeId);
        List<JobDto> dtoList = new List<JobDto>();

        foreach (Job job in jobList)
        {
            dtoList.Add(JobDto.createJobDTO(job));
        }

        return dtoList;
    }

    public List<JobDto> selectJobIdNotDoneByRecruiteeId(String recruiteeId)
    {
        JobManager mgr = new JobManager();
        List<Job> jobList = mgr.selectJobIdNotDoneByRecruiteeId(recruiteeId);
        List<JobDto> dtoList = new List<JobDto>();

        foreach (Job job in jobList)
        {
            dtoList.Add(JobDto.createJobDTO(job));
        }

        return dtoList;
    }

    public JobDto selectJobById(JobDto dto)
    {
        JobManager mgr = new JobManager();
        Job obj = new Job();
        obj.JobId = dto.JobId;
        obj = mgr.selectJobById(obj);
        if (obj != null)
        {
            return JobDto.createJobDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertJob(JobDto dto)
    {
        Job obj = Job.createJob(dto.JobId, dto.JobName, dto.CompensationId, dto.EmployerId, dto.JobDescription, dto.JobQuota, (decimal)dto.JobExperienceLevel, (decimal)dto.JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.insertJob(obj);
    }

    public Boolean updateJob(JobDto dto)
    {
        Job obj = Job.createJob(dto.JobId, dto.JobName, dto.CompensationId, dto.EmployerId, dto.JobDescription, dto.JobQuota, (decimal)dto.JobExperienceLevel, (decimal)dto.JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.updateJob(obj);
    }

    public Boolean deleteJob(JobDto dto)
    {
        Job obj = Job.createJob(dto.JobId, dto.JobName, dto.CompensationId, dto.EmployerId, dto.JobDescription, dto.JobQuota, (decimal)dto.JobExperienceLevel, (decimal)dto.JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.deleteJob(obj);
    }

    public JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue)
    {
        return JobDto.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
    }

    public Boolean addSkillToJob(System.Guid JobId, String SkillId)
    {
        JobManager mgr = new JobManager();
        Job job = new Job();
        job.JobId = JobId;
        Job obj = mgr.selectJobById(job);
        return mgr.addSkillToJob(obj, SkillId);
    }

    public Boolean removeSkillFromJob(System.Guid JobId, String SkillId)
    {
        JobManager mgr = new JobManager();
        Job job = new Job();
        job.JobId = JobId;
        Job obj = mgr.selectJobById(job);
        return mgr.removeSkillFromJob(obj, SkillId);
    }

    public List<JobDto> selectJobBySkillId(String skillId)
    {
        JobManager mgr = new JobManager();
        List<Job> jobList = mgr.selectJobBySkillId(skillId);
        List<JobDto> dtoList = new List<JobDto>();

        foreach (Job job in jobList)
        {
            dtoList.Add(JobDto.createJobDTO(job));
        }

        return dtoList;
    }

    [OperationContract]
    public Guid[] selectExpressionNames()
    {
        JobManager mgr = new JobManager();
        return mgr.selectExpressionNames();
    }

    [OperationContract]
    public double[] selectExpressionDifficulty()
    {
        JobManager mgr = new JobManager();
        return mgr.selectExpressionDifficulty();

    }

    #endregion

    #region Skill

    public List<SkillDto> selectAllSkill()
    {
        SkillManager mgr = new SkillManager();
        List<Skill> skillList = mgr.selectAllSkill();
        List<SkillDto> dtoList = new List<SkillDto>();

        foreach (Skill skill in skillList)
        {
            dtoList.Add(SkillDto.createSkillDTO(skill));
        }

        return dtoList;
    }

    public SkillDto selectSkillById(SkillDto dto)
    {
        SkillManager mgr = new SkillManager();
        Skill obj = new Skill();
        obj.SkillId = dto.SkillId;
        obj = mgr.selectSkillById(obj);
        if (obj != null)
        {
            return SkillDto.createSkillDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertSkill(SkillDto dto)
    {
        Skill obj = Skill.createSkill(dto.SkillId, dto.SkillName, dto.SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.insertSkill(obj);
    }

    public Boolean updateSkill(SkillDto dto)
    {
        Skill obj = Skill.createSkill(dto.SkillId, dto.SkillName, dto.SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.updateSkill(obj);
    }

    public Boolean deleteSkill(SkillDto dto)
    {
        Skill obj = Skill.createSkill(dto.SkillId, dto.SkillName, dto.SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.deleteSkill(obj);
    }

    #endregion

}