using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMRecruiteeWebsite.Service.Interface;


namespace UMRecruiteeWebsite.Service.Interface
{
    
    public interface IFileSystemSvc : IService
    {
        string MapDirectoryPath(string name);   
    }
}