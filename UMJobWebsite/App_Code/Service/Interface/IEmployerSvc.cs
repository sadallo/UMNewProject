using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;

namespace UMJobWebsite.Service.Interface
{
    public interface IEmployerSvc : IService
    {
        List<Employer> selectAllEmployer();
        Employer selectEmployerById(Employer obj);
        Boolean insertEmployer(Employer obj);
        Boolean updateEmployer(Employer obj);
        Boolean deleteEmployer(Employer obj);
    }
}