using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.Service.Interface
{
    public interface IEducationSvc : IService
    {
        List<Education> selectAllEducation();
        Education selectEducationById(Education obj);
        Boolean insertEducation(Education obj);
        Boolean updateEducation(Education obj);
        Boolean deleteEducation(Education obj);
    }
}
