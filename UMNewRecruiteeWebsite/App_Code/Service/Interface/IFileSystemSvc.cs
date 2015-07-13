using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewRecruiteeWebsite.Service.Interface;


namespace UMNewRecruiteeWebsite.Service.Interface
{
    
    public interface IFileSystemSvc : IService
    {
        string MapDirectoryPath(string name);   
    }
}