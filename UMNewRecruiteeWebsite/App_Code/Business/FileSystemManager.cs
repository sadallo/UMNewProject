    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewRecruiteeWebsite.Exceptions.Service;
using UMNewRecruiteeWebsite.Service.Interface;


namespace UMNewRecruiteeWebsite.Business
{
    public class FileSystemManager : BusinessManager
    {
        public string MapDirectoryPath(string name)
        {
            try
            {
                IFileSystemSvc svcFileSystem = (IFileSystemSvc)this.getService(typeof(IFileSystemSvc).Name);
                return svcFileSystem.MapDirectoryPath(name);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }

        }
    }
}