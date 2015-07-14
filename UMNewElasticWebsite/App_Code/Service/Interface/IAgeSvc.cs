using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IAgeSvc : IService
    {
        List<AgeDto> selectAllAge();
        AgeDto selectAgeById(AgeDto obj);
        Boolean insertAge(AgeDto obj);
        Boolean updateAge(AgeDto obj);
        Boolean deleteAge(AgeDto obj);
        //AgeDto createAgeDTO(...)
    }
}