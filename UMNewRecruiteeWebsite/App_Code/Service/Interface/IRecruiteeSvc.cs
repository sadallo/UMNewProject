using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.Service.Interface
{
    public interface IRecruiteeSvc : IService
    {
        List<Recruitee> selectAllRecruitee();
        Recruitee selectRecruiteeById(Recruitee obj);
        Recruitee selectRecruiteeByEmail(Recruitee obj);
        List<Recruitee> selectRecruiteeBySkillId(String skillId);
        Boolean insertRecruitee(Recruitee obj);
        Boolean updateRecruitee(Recruitee obj);
        Boolean deleteRecruitee(Recruitee obj);
        Boolean addSkillToRecruitee(Recruitee obj, String skillId);
        Boolean removeSkillFromRecruitee(Recruitee obj, String skillId);
        Guid[] selectRecruiteeNames();


    }
}
