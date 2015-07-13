using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMatlabSvc
/// </summary>

namespace UMRecruiteeWebsite.Service.Interface
{
    public interface IMatlabSvc : IService
    {
        void MatlabExecute();
        object MatlabExecuteComputeCost(int[,] X, int[,] y, int[,] theta);
        object MatlabExecuteGradientDescent(int[,] X, int[,] y, int[,] theta, int alpha, int numInteraction);

    }
}