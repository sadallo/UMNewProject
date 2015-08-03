using UMNewElasticWebsite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMNewElasticWebsite.Service.Interface
{
    public interface IMatlabSvc : IService
    {
        bool changeDirectory(String path);
        object[] executeFilter(TaskDimensions task, String[] job_list, String path, double[,] my_ratings, double[,] Y, double[,] R, double[,] X);
    }
}
