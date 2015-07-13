using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Models;

namespace UMRecruiteeWebsite.Service.Interface
{
    public interface IRecruiteeSvc : IService
    {
        List<Recruitee> selectAllRecruitee();
        Recruitee selectRecruiteeById(Recruitee obj);
        List<Recruitee> selectRecruiteeBySkillId(String skillId);
        Boolean insertRecruitee(Recruitee obj);
        Boolean updateRecruitee(Recruitee obj);
        Boolean deleteRecruitee(Recruitee obj);
        Boolean addSkillToRecruitee(Recruitee obj, String skillId);
        Boolean removeSkillFromRecruitee(Recruitee obj, String skillId);


    }
}
