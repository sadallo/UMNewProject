using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UMNewRecruiteeWebsite.DomainDTO;

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

    #region Recruitee

    [OperationContract]
    List<RecruiteeDto> selectAllRecruitee();

    [OperationContract]
    RecruiteeDto selectRecruiteeById(RecruiteeDto obj);

    [OperationContract]
    List<RecruiteeDto> selectRecruiteeBySkillId(String skillId);

    [OperationContract]
    Boolean insertRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean updateRecruitee(RecruiteeDto obj);

    [OperationContract]
    Boolean deleteRecruitee(RecruiteeDto obj);

    [OperationContract]
    RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue);

    [OperationContract]
    Boolean addSkillToRecruitee(System.Guid RecruiteeId, String SkillId);

    [OperationContract]
    Boolean removeSkillFromRecruitee(System.Guid RecruiteeId, String SkillId);

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
