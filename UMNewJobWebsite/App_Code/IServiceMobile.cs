using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewJobWebsite.DomainDTO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMobile" in both code and config file together.
[ServiceContract]
public interface IServiceMobile
{
	
	
    #region Category
    [OperationContract]
    List<CategoryDto> selectAllCategory();

    [OperationContract]
    CategoryDto selectCategoryById(String CategoryId);

    [OperationContract]
    Boolean insertCategory(String CategoryId, String CategoryName, String CategoryDescription);

    [OperationContract]
    Boolean updateCategory(String CategoryId, String CategoryName, String CategoryDescription);

    [OperationContract]
    Boolean deleteCategory(String CategoryId, String CategoryName, String CategoryDescription);
    #endregion

    #region Compensation

    [OperationContract]
    List<CompensationDto> selectAllCompensation();

    [OperationContract]
    CompensationDto selectCompensationById(String CompensationId);

    [OperationContract]
    Boolean insertCompensation(String CompensationId, String CompensationType, String CompensationDescription);

    [OperationContract]
    Boolean updateCompensation(String CompensationId, String CompensationType, String CompensationDescription);

    [OperationContract]
    Boolean deleteCompensation(String CompensationId, String CompensationType, String CompensationDescription);

    #endregion

    #region Employer

    [OperationContract]
    List<EmployerDto> selectAllEmployer();

    [OperationContract]
    EmployerDto selectEmployerById(System.Guid EmployerId);

    [OperationContract]
    Boolean insertEmployer(System.Guid EmployerId, String EmployerName);

    [OperationContract]
    Boolean updateEmployer(System.Guid EmployerId, String EmployerName);

    [OperationContract]
    Boolean deleteEmployer(System.Guid EmployerId, String EmployerName);

    #endregion

    #region Job

    [OperationContract]
    List<JobDto> selectAllJob();

    [OperationContract]
    List<JobDto> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId);

    [OperationContract]
    List<JobDto> selectJobIdNotDoneByRecruiteeId(String recruiteeId);

    [OperationContract]
    JobDto selectJobById(System.Guid JobId);

    [OperationContract]
    Boolean insertJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
    Boolean updateJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
    Boolean deleteJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);
    [OperationContract]
    JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                       String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue);

    [OperationContract]
    Boolean addSkillToJob(System.Guid JobId, String SkillId);
    
    [OperationContract]
    Boolean removeSkillFromJob(System.Guid JobId, String SkillId);
    
    [OperationContract]
    List<JobDto> selectJobBySkillId(String skillId);

    [OperationContract]
    Guid[] selectExpressionNames();

    [OperationContract]
    double[] selectExpressionDifficulty();

    #endregion

    #region Skill

    [OperationContract]
    List<SkillDto> selectAllSkill();

    [OperationContract]
    SkillDto selectSkillById(String SkillId);

    [OperationContract]
    Boolean insertSkill(String SkillId, String SkillName, String SkillDescription);

    [OperationContract]
    Boolean updateSkill(String SkillId, String SkillName, String SkillDescription);

    [OperationContract]
    Boolean deleteSkill(String SkillId, String SkillName, String SkillDescription);

    #endregion
}

