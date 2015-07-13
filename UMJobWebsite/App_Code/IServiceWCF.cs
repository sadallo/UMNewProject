using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMJobWebsite.DomainDTO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IServiceWCF
{
	
    #region Category
    [OperationContract]
    List<CategoryDto> selectAllCategory();

    [OperationContract]
    CategoryDto selectCategoryById(CategoryDto obj);

    [OperationContract]
    Boolean insertCategory(CategoryDto obj);

    [OperationContract]
    Boolean updateCategory(CategoryDto obj);

    [OperationContract]
    Boolean deleteCategory(CategoryDto obj);
    #endregion

    #region Compensation

    [OperationContract]
    List<CompensationDto> selectAllCompensation();

    [OperationContract]
    CompensationDto selectCompensationById(CompensationDto obj);

    [OperationContract]
    Boolean insertCompensation(CompensationDto obj);

    [OperationContract]
    Boolean updateCompensation(CompensationDto obj);

    [OperationContract]
    Boolean deleteCompensation(CompensationDto obj);

    #endregion

    #region Employer

    [OperationContract]
    List<EmployerDto> selectAllEmployer();

    [OperationContract]
    EmployerDto selectEmployerById(EmployerDto obj);

    [OperationContract]
    Boolean insertEmployer(EmployerDto obj);

    [OperationContract]
    Boolean updateEmployer(EmployerDto obj);

    [OperationContract]
    Boolean deleteEmployer(EmployerDto obj);

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
    Boolean addSkillToJob(System.Guid JobId, String SkillId);

    [OperationContract]
    Boolean removeSkillFromJob(System.Guid JobId, String SkillId);

    [OperationContract]
    List<JobDto> selectJobBySkillId(String skillId);
    #endregion

    #region Skill

    [OperationContract]
    List<SkillDto> selectAllSkill();

    [OperationContract]
    SkillDto selectSkillById(SkillDto obj);

    [OperationContract]
    Boolean insertSkill(SkillDto obj);

    [OperationContract]
    Boolean updateSkill(SkillDto obj);

    [OperationContract]
    Boolean deleteSkill(SkillDto obj);

    #endregion
}
