using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Service.Interface;


namespace UMNewJobWebsite.Service.Interface
{
    
    public interface IFileSystemSvc : IService
    {
        string MapDirectoryPath(string name);   
    }
}