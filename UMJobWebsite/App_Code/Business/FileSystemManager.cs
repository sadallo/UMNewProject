using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;
using UMJobWebsite.Exceptions.Service;
using UMJobWebsite.Service.Interface;

namespace UMJobWebsite.Business
{
    public class FileSystemManager : BusinessManager
    {
        public string MapDirectoryPath(string name)
        {
            try
            {
                IFileSystemSvc svc = (IFileSystemSvc)this.getService(typeof(IFileSystemSvc).Name);
                return svc.MapDirectoryPath(name);

            }

            catch (ServiceLoadException ex)
            {
                return null;
            }
        }
    }
}