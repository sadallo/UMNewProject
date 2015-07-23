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

    public RankingDto selectRankingById(RankingDto dto)
    {
        RankingManager mgr = new RankingManager();
        Ranking obj = new Ranking();
        obj.RankingId = dto.RankingId;
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

    public Boolean insertRanking(RankingDto dto)
    {
        Ranking obj = Ranking.createRanking(dto.RankingId, dto.RankingName);
        RankingManager mgr = new RankingManager();
        return mgr.insertRanking(obj);
    }

    public Boolean updateRanking(RankingDto dto)
    {
        Ranking obj = Ranking.createRanking(dto.RankingId, dto.RankingName);
        RankingManager mgr = new RankingManager();
        return mgr.updateRanking(obj);
    }

    public Boolean deleteRanking(RankingDto dto)
    {
        Ranking obj = Ranking.createRanking(dto.RankingId, dto.RankingName);
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

    public RecruiteeDto selectRecruiteeById(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee obj = new Recruitee();
        obj.RecruiteeId = dto.RecruiteeId;
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

    public RecruiteeDto selectRecruiteeByEmail(RecruiteeDto dto)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee obj = new Recruitee();
        obj.Email = dto.Email;
        obj = mgr.selectRecruiteeByEmail(obj);

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

    public Boolean insertRecruitee(RecruiteeDto dto)
    {
        if (dto.AgeId.Equals(""))
        {
            dto.AgeId = null;
        }

        if (dto.EducationId.Equals(""))
        {
            dto.EducationId = null;
        }

        if (dto.IncomeId.Equals(""))
        {
            dto.IncomeId = null;
        }

        if (dto.RankingId.Equals(""))
        {
            dto.RankingId = null;
        }

        Recruitee obj = Recruitee.createRecruitee(dto.RecruiteeId, dto.RankingId, (decimal)dto.RankingValue, dto.Email,
                           dto.FirstName, dto.LastName, dto.Gender, dto.AgeId, dto.EducationId, dto.IncomeId); 
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.insertRecruitee(obj);
    }

    public Boolean updateRecruitee(RecruiteeDto dto)
    {
        if (dto.AgeId != null && dto.AgeId.Equals(""))
        {
            dto.AgeId = null;
        }

        if (dto.EducationId != null && dto.EducationId.Equals(""))
        {
            dto.EducationId = null;
        }

        if (dto.IncomeId != null && dto.IncomeId.Equals(""))
        {
            dto.IncomeId = null;
        }

        if (dto.RankingId != null && dto.RankingId.Equals(""))
        {
            dto.RankingId = null;
        }
        Recruitee obj = Recruitee.createRecruitee(dto.RecruiteeId, dto.RankingId, (decimal)dto.RankingValue, dto.Email,
                           dto.FirstName, dto.LastName, dto.Gender, dto.AgeId, dto.EducationId, dto.IncomeId); 
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.updateRecruitee(obj);
    }

    public Boolean deleteRecruitee(RecruiteeDto dto)
    {
        Recruitee obj = Recruitee.createRecruitee(dto.RecruiteeId, dto.RankingId, (decimal)dto.RankingValue, dto.Email,
                           dto.FirstName, dto.LastName, dto.Gender, dto.AgeId, dto.EducationId, dto.IncomeId); 
        RecruiteeManager mgr = new RecruiteeManager();
        return mgr.deleteRecruitee(obj);
    }

    public RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
    {
        return RecruiteeDto.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email,
                   FirstName, LastName, Gender, AgeId, EducationId, IncomeId);
    }

    public Boolean addSkillToRecruitee(Guid RecruiteeId, String SkillId)
    {
        RecruiteeManager mgr = new RecruiteeManager();
        Recruitee rec = Recruitee.createRecruitee(RecruiteeId, null, 0, "", "", "", "", "", "", "");
        Recruitee obj = mgr.selectRecruiteeById(rec);
        return mgr.addSkillToRecruitee(obj, SkillId);
    }

    public Boolean removeSkillFromRecruitee(Guid RecruiteeId, String SkillId)
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

    #region Age

    public List<AgeDto> selectAllAge()
    {
        AgeManager mgr = new AgeManager();
        List<Age> ageList = mgr.selectAllAge();
        List<AgeDto> dtoList = new List<AgeDto>();

        foreach (Age age in ageList)
        {
            dtoList.Add(AgeDto.createAgeDTO(age));
        }

        return dtoList;
    }

    public AgeDto selectAgeById(AgeDto dto)
    {
        AgeManager mgr = new AgeManager();
        Age obj = new Age();
        obj.AgeId = dto.AgeId;
        obj = mgr.selectAgeById(obj);
        if (obj != null)
        {
            return AgeDto.createAgeDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertAge(AgeDto dto)
    {
        Age obj = Age.createAge(dto.AgeId, dto.AgeDescription);
        AgeManager mgr = new AgeManager();
        return mgr.insertAge(obj);
    }

    public Boolean updateAge(AgeDto dto)
    {
        Age obj = Age.createAge(dto.AgeId, dto.AgeDescription);
        AgeManager mgr = new AgeManager();
        return mgr.updateAge(obj);
    }

    public Boolean deleteAge(AgeDto dto)
    {
        Age obj = Age.createAge(dto.AgeId, dto.AgeDescription);
        AgeManager mgr = new AgeManager();
        return mgr.deleteAge(obj);
    }

    #endregion

    #region Education

    public List<EducationDto> selectAllEducation()
    {
        EducationManager mgr = new EducationManager();
        List<Education> eduList = mgr.selectAllEducation();
        List<EducationDto> dtoList = new List<EducationDto>();

        foreach (Education edu in eduList)
        {
            dtoList.Add(EducationDto.createEducationDTO(edu));
        }

        return dtoList;
    }

    public EducationDto selectEducationById(EducationDto dto)
    {
        EducationManager mgr = new EducationManager();
        Education obj = new Education();
        obj.EducationId = dto.EducationId;
        obj = mgr.selectEducationById(obj);
        if (obj != null)
        {
            return EducationDto.createEducationDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertEducation(EducationDto dto)
    {
        Education obj = Education.createEducation(dto.EducationId, dto.EducationDescription);
        EducationManager mgr = new EducationManager();
        return mgr.insertEducation(obj);
    }

    public Boolean updateEducation(EducationDto dto)
    {
        Education obj = Education.createEducation(dto.EducationId, dto.EducationDescription);
        EducationManager mgr = new EducationManager();
        return mgr.updateEducation(obj);
    }

    public Boolean deleteEducation(EducationDto dto)
    {
        Education obj = Education.createEducation(dto.EducationId, dto.EducationDescription);
        EducationManager mgr = new EducationManager();
        return mgr.deleteEducation(obj);
    }

    #endregion

    #region Income

    public List<IncomeDto> selectAllIncome()
    {
        IncomeManager mgr = new IncomeManager();
        List<Income> incList = mgr.selectAllIncome();
        List<IncomeDto> dtoList = new List<IncomeDto>();

        foreach (Income inc in incList)
        {
            dtoList.Add(IncomeDto.createIncomeDTO(inc));
        }

        return dtoList;
    }

    public IncomeDto selectIncomeById(IncomeDto dto)
    {
        IncomeManager mgr = new IncomeManager();
        Income obj = new Income();
        obj.IncomeId = dto.IncomeId;
        obj = mgr.selectIncomeById(obj);
        if (obj != null)
        {
            return IncomeDto.createIncomeDTO(obj);
        }
        else
        {
            return null;
        }
    }

    public Boolean insertIncome(IncomeDto dto)
    {
        Income obj = Income.createIncome(dto.IncomeId, dto.IncomeDescription);
        IncomeManager mgr = new IncomeManager();
        return mgr.insertIncome(obj);
    }

    public Boolean updateIncome(IncomeDto dto)
    {
        Income obj = Income.createIncome(dto.IncomeId, dto.IncomeDescription);
        IncomeManager mgr = new IncomeManager();
        return mgr.updateIncome(obj);
    }

    public Boolean deleteIncome(IncomeDto dto)
    {
        Income obj = Income.createIncome(dto.IncomeId, dto.IncomeDescription);
        IncomeManager mgr = new IncomeManager();
        return mgr.deleteIncome(obj);
    }

    #endregion


}
