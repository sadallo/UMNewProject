using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using UMNewElasticWebsite.Domain;
using NewRecruiteeService;

namespace UMNewElasticWebsite.Business
{
    public class MatlabManager : BusinessManager
    {
        public bool changeDirectory(String path)
        {
            try
            {
                IMatlabSvc svc = (IMatlabSvc)this.getService(typeof(IMatlabSvc).Name);
                return svc.changeDirectory(path);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public object[] executeFilter(TaskDimensions task, String[] job_list, String path, double[,] my_ratings, double[,] Y, double[,] R, double[,] X)
        {
            try
            {
                IMatlabSvc svc = (IMatlabSvc)this.getService(typeof(IMatlabSvc).Name);
                return svc.executeFilter(task, job_list, path, my_ratings, Y, R, X);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }
    }
       
}
