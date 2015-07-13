using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Service.Interface;


namespace UMJobWebsite.Service.Interface
{
    
    public interface IFileSystemSvc : IService
    {
        string MapDirectoryPath(string name);   
    }
}