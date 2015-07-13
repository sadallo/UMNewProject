using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewRecruiteeWebsite.DomainDTO;

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

    #region Ranking
    [OperationContract]
    List<RankingDto> selectAllRanking();

    [OperationContract]
    RankingDto selectRankingById(String RankingId);

    [OperationContract]
    List<RecruiteeDto> selectRecruiteeBySkillId(String skillId);

    [OperationContract]
    Boolean insertRanking(String RankingId, String RankingName);

    [OperationContract]
    Boolean updateRanking(String RankingId, String RankingName);

    [OperationContract]
    Boolean deleteRanking(String RankingId, String RankingName);

    [OperationContract]
    RankingDto createRankingDTO(String RankingId, String RankingName);



    #endregion

    #region Recruitee

    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();

    [OperationContract]
    RecruiteeDto selectRecruiteeById(System.Guid RecruiteeId);

    [OperationContract]
    Boolean insertRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    Boolean updateRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    Boolean deleteRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId);

    [OperationContract]
    Boolean addSkillToRecruitee(System.Guid RecruiteeId, String SkillId);

    [OperationContract]
    Boolean removeSkillFromRecruitee(System.Guid RecruiteeId, String SkillId);

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

    #region Age
    [OperationContract]
    List<AgeDto> selectAllAge();

    [OperationContract]
    AgeDto selectAgeById(String AgeId);

    [OperationContract]
    Boolean insertAge(String AgeId, String AgeDescription);

    [OperationContract]
    Boolean updateAge(String AgeId, String AgeDescription);

    [OperationContract]
    Boolean deleteAge(String AgeId, String AgeDescription);

    #endregion

    #region Education
    [OperationContract]
    List<EducationDto> selectAllEducation();

    [OperationContract]
    EducationDto selectEducationById(String EducationId);

    [OperationContract]
    Boolean insertEducation(String EducationId, String EducationDescription);

    [OperationContract]
    Boolean updateEducation(String EducationId, String EducationDescription);

    [OperationContract]
    Boolean deleteEducation(String EducationId, String EducationDescription);

    #endregion

    #region Income
    [OperationContract]
    List<IncomeDto> selectAllIncome();

    [OperationContract]
    IncomeDto selectIncomeById(String IncomeId);

    [OperationContract]
    Boolean insertIncome(String IncomeId, String IncomeDescription);

    [OperationContract]
    Boolean updateIncome(String IncomeId, String IncomeDescription);

    [OperationContract]
    Boolean deleteIncome(String IncomeId, String IncomeDescription);

    #endregion


}
