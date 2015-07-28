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

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMobile" in code, svc and config file together.
public class ServiceMobile : IServiceMobile
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

    public CategoryDto selectCategoryById(String CategoryId)
    {
        CategoryManager mgr = new CategoryManager();
        Category obj = new Category();
        obj.CategoryId = CategoryId;
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

    public Boolean insertCategory(String CategoryId, String CategoryName, String CategoryDescription)
    {
        Category obj = Category.createCategory(CategoryId, CategoryName, CategoryDescription);
        CategoryManager mgr = new CategoryManager();
        return mgr.insertCategory(obj);
    }

    public Boolean updateCategory(String CategoryId, String CategoryName, String CategoryDescription)
    {
        Category obj = Category.createCategory(CategoryId, CategoryName, CategoryDescription);
        CategoryManager mgr = new CategoryManager();
        return mgr.updateCategory(obj);
    }

    public Boolean deleteCategory(String CategoryId, String CategoryName, String CategoryDescription)
    {
        Category obj = Category.createCategory(CategoryId, CategoryName, CategoryDescription);
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

    public CompensationDto selectCompensationById(String CompensationId)
    {
        CompensationManager mgr = new CompensationManager();
        Compensation obj = new Compensation();
        obj.CompensationId = CompensationId;
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

    public Boolean insertCompensation(String CompensationId, String CompensationType, String CompensationDescription)
    {
        Compensation obj = Compensation.createCompensation(CompensationId, CompensationType, CompensationDescription);
        CompensationManager mgr = new CompensationManager();
        return mgr.insertCompensation(obj);
    }

    public Boolean updateCompensation(String CompensationId, String CompensationType, String CompensationDescription)
    {
        Compensation obj = Compensation.createCompensation(CompensationId, CompensationType, CompensationDescription);
        CompensationManager mgr = new CompensationManager();
        return mgr.updateCompensation(obj);
    }

    public Boolean deleteCompensation(String CompensationId, String CompensationType, String CompensationDescription)
    {
        Compensation obj = Compensation.createCompensation(CompensationId, CompensationType, CompensationDescription);
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

    public EmployerDto selectEmployerById(System.Guid EmployerId)
    {
        EmployerManager mgr = new EmployerManager();
        Employer obj = new Employer();
        obj.EmployerId = EmployerId;
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

    public Boolean insertEmployer(System.Guid EmployerId, String EmployerName)
    {
        Employer obj = Employer.createEmployer(EmployerId, EmployerName);
        EmployerManager mgr = new EmployerManager();
        return mgr.insertEmployer(obj);
    }

    public Boolean updateEmployer(System.Guid EmployerId, String EmployerName)
    {
        Employer obj = Employer.createEmployer(EmployerId, EmployerName);
        EmployerManager mgr = new EmployerManager();
        return mgr.updateEmployer(obj);
    }

    public Boolean deleteEmployer(System.Guid EmployerId, String EmployerName)
    {
        Employer obj = Employer.createEmployer(EmployerId, EmployerName);
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

    public List<JobDto> selectJobByRecruiteeIdRecommendation(String recruiteeId)
    {
        JobManager mgr = new JobManager();
        List<Job> jobList = mgr.selectJobByRecruiteeIdRecommendation(recruiteeId);
        List<JobDto> dtoList = new List<JobDto>();

        foreach (Job job in jobList)
        {
            dtoList.Add(JobDto.createJobDTO(job));
        }

        return dtoList;
    }

    public JobDto selectJobById(System.Guid JobId)
    {
        JobManager mgr = new JobManager();
        Job obj = new Job();
        obj.JobId = JobId;
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

    public Boolean insertJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        Job obj = Job.createJob(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.insertJob(obj);
    }

    public Boolean updateJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        Job obj = Job.createJob(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.updateJob(obj);
    }

    public Boolean deleteJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
    {
        Job obj = Job.createJob(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
        JobManager mgr = new JobManager();
        return mgr.deleteJob(obj);
    }

    public JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
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

    public SkillDto selectSkillById(String SkillId)
    {
        SkillManager mgr = new SkillManager();
        Skill obj = new Skill();
        obj.SkillId = SkillId;
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

    public Boolean insertSkill(String SkillId, String SkillName, String SkillDescription)
    {
        Skill obj = Skill.createSkill(SkillId, SkillName, SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.insertSkill(obj);
    }

    public Boolean updateSkill(String SkillId, String SkillName, String SkillDescription)
    {
        Skill obj = Skill.createSkill(SkillId, SkillName, SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.updateSkill(obj);
    }

    public Boolean deleteSkill(String SkillId, String SkillName, String SkillDescription)
    {
        Skill obj = Skill.createSkill(SkillId, SkillName, SkillDescription);
        SkillManager mgr = new SkillManager();
        return mgr.deleteSkill(obj);
    }

    #endregion
}
