using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;

namespace UMJobWebsite.Service.Interface
{
    
        public interface ICompensationSvc : IService
        {
            List<Compensation> selectAllCompensation();
            Compensation selectCompensationById(Compensation obj);
            Boolean insertCompensation(Compensation obj);
            Boolean updateCompensation(Compensation obj);
            Boolean deleteCompensation(Compensation obj);
        }
    
}