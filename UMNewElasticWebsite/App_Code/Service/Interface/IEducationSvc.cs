using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IEducationSvc : IService
    {
        List<EducationDto> selectAllEducation();
        EducationDto selectEducationById(EducationDto obj);
        Boolean insertEducation(EducationDto obj);
        Boolean updateEducation(EducationDto obj);
        Boolean deleteEducation(EducationDto obj);
        //EducationDto createEducationDTO(...)
    }
}