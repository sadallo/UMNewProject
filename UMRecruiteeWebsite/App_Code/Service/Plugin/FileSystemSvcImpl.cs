using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMRecruiteeWebsite.Service.Interface;

/// <summary>
/// Summary description for FileSystemSvcImp
/// </summary>
namespace UMRecruiteeWebsite.Service.Plugin
{
    public class FileSystemSvcImpl : IFileSystemSvc
    {
        public FileSystemSvcImpl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string MapDirectoryPath(string name)
        {
            return HttpContext.Current.Server.MapPath("~/") + name;
        }
    }

}