using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using UMNewRecruiteeWebsite.Business;
using UMNewRecruiteeWebsite.DomainDTO;
using UMNewRecruiteeWebsite.Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMobile" in code, svc and config file together.
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
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

    #region Ranking

    public List<RankingDto> selectAllRanking()
    {
        RankingManager mgr = new RankingManager();
        List<Ranking> ranList = mgr.selectAllRanking();
        List<RankingDto> dtoList = new List<RankingDto>();

        foreach (Ranking ran in ranList)
        {
            dtoList.Add(RankingDto.createRankingDTO(ran));
        }

        return dtoList;
    }

    public RankingDto selectRankingById(String RankingId)
    {
        RankingManager mgr = new RankingManager();
        Ranking obj = new Ranking();
        obj.RankingId = RankingId;
        obj = mgr.selectRankingById(obj);
        if (obj != null)
        {
            return RankingDto.createRankingDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertRanking(String RankingId, String RankingName)
    {
        Ranking obj = Ranking.createRanking(RankingId, RankingName);
        RankingManager mgr = new RankingManager();
        return mgr.insertRanking(obj);
    }

    public Boolean updateRanking(String RankingId, String RankingName)
    {
        Ranking obj = Ranking.createRanking(RankingId, RankingName);
        RankingManager mgr = new RankingManager();
        return mgr.updateRanking(obj);
    }

    public Boolean deleteRanking(String RankingId, String RankingName)
    {
        Ranking obj = Ranking.createRanking(RankingId, RankingName);
        RankingManager mgr = new RankingManager();
        return mgr.deleteRanking(obj);
    }

    public RankingDto createRankingDTO(String RankingId, String RankingName)
    {
        return RankingDto.createRankingDTO(RankingId, RankingName);
    }

    #endregion

    #region Recruitee

    public List<RecruiteeDto> selectAllRecruitee()
    {
        RecruiteeManager mgr = new RecruiteeManager();
        List<Recruitee> recList = mgr.selectAllRecruitee();
        List<RecruiteeDto> dtoList = new List<RecruiteeDto>();

        foreach (Recruitee rec in recList)
        {
            dtoList.Add(RecruiteeDto.createRecruiteeDTO(rec));
        }

        return dtoList;
    }

    public RecruiteeDto selectRecruiteeById(System.Guid RecruiteeId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee obj = new Recruitee();
        obj.RecruiteeId = RecruiteeId;
        obj = mgr.selectRecruiteeById(obj);

        if (obj != null)
        {
            return RecruiteeDto.createRecruiteeDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public List<RecruiteeDto> selectRecruiteeBySkillId(String skillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        List<Recruitee> recList = mgr.selectRecruiteeBySkillId(skillId);
        List<RecruiteeDto> dtoList = new List<RecruiteeDto>();

        foreach (Recruitee rec in recList)
        {
            dtoList.Add(RecruiteeDto.createRecruiteeDTO(rec));
        }

        return dtoList;
    }

    public Boolean insertRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        if (RankingId.Equals(""))
        {
            RankingId = null;
        }
        Recruitee obj = Recruitee.createRecruitee(RecruiteeId, RankingId, (decimal)RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.insertRecruitee(obj);
    }

    public Boolean updateRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        Recruitee obj = Recruitee.createRecruitee(RecruiteeId, RankingId, (decimal)RankingValue, Email,
                           FirstName, LastName, Gender, AgeId, EducationId, IncomeId); 
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.updateRecruitee(obj);
    }

    public Boolean deleteRecruitee(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        Recruitee obj = Recruitee.createRecruitee(RecruiteeId, RankingId, (decimal)RankingValue, Email,
                           FirstName, LastName, Gender, AgeId, EducationId, IncomeId); 
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.deleteRecruitee(obj);
    }

    public RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        return RecruiteeDto.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
    }

    public Boolean addSkillToRecruitee(System.Guid RecruiteeId, String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee rec = Recruitee.createRecruitee(RecruiteeId, null, 0, "", "", "", "", "", "", "");
        Recruitee obj = mgr.selectRecruiteeById(rec);
        return mgr.addSkillToRecruitee(obj, SkillId);
    }

    public Boolean removeSkillFromRecruitee(System.Guid RecruiteeId, String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee rec = Recruitee.createRecruitee(RecruiteeId, null, 0, "", "", "", "", "", "", "");
        Recruitee obj = mgr.selectRecruiteeById(rec);
        return mgr.removeSkillFromRecruitee(obj, SkillId);
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
