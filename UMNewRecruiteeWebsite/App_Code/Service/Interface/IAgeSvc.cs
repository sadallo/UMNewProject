using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.Service.Interface

{
    public interface IAgeSvc : IService
    {
        List<Age> selectAllAge();
        Age selectAgeById(Age obj);
        Boolean insertAge(Age obj);
        Boolean updateAge(Age obj);
        Boolean deleteAge(Age obj);
    }
}
