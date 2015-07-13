using NewRecruiteeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMNewElasticWebsite.Service.Interface
{
    public interface IFileSystemSvc
    {
        List<RecruiteeDto> readRecruitees(String path); 
    }
}
