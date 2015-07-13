using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Service.Interface;
using MLApp;
using UMNewJobWebsite.Business;
using UMNewJobWebsite.Exceptions;


/// <summary>
/// Summary description for MatlabSvcImpl
/// </summary>
/// 
namespace UMNewJobWebsite.Service.Plugin
{
    public class MatlabSvcImpl : IMatlabSvc
    {
        private MLApp.MLApp matlab = null;

        public MatlabSvcImpl(string directory)
        {
            this.matlab = new MLApp.MLApp();
        }

        public void MatlabExecute()
        {
            this.matlab.Execute(@"cd " + (new FileSystemManager()).MapDirectoryPath(Constants.CustomDirectories.MATLAB_WORKSPACE));
        }

        public object MatlabExecuteComputeCost(int[,] X, int[,] y, int[,] theta)
        {
            this.matlab.Execute(@"cd " + (new FileSystemManager()).MapDirectoryPath(Constants.CustomDirectories.MATLAB_WORKSPACE));
            object result = null;
            
            matlab.Feval(Constants.CustomDirectories.COMPUTE_COST, 1, out result, X, y, theta);

            object[] res = result as object[];

            return res[0];
        }

        public object MatlabExecuteGradientDescent(int[,] X, int[,] y, int[,] theta, int alpha, int numInteraction)
        {
            this.matlab.Execute(@"cd " + (new FileSystemManager()).MapDirectoryPath(Constants.CustomDirectories.MATLAB_WORKSPACE));
            object result = null;

            matlab.Feval(Constants.CustomDirectories.GRADIENT_DESCENT, 1, out result, X, y, theta, alpha, numInteraction);

            object[] res = result as object[];

            return res[0];
        }


    }
}