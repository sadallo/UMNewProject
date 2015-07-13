using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Service.Interface;


namespace UMNewJobWebsite.Business
{
    public class MatlabManager : BusinessManager
    {
        public void MatlabExecute()
        {
            IMatlabSvc svcMatlab = (IMatlabSvc)this.getService(typeof(IMatlabSvc).Name);
            svcMatlab.MatlabExecute();
        }

        public object MatlabExecuteComputeCost(int[,] X, int[,] y, int[,] theta)
        {
            IMatlabSvc svcMatlab = (IMatlabSvc)this.getService(typeof(IMatlabSvc).Name);
            return svcMatlab.MatlabExecuteComputeCost(X, y, theta);
        }

        public object MatlabExecuteGradientDescent(int[,] X, int[,] y, int[,] theta, int alpha, int numInteraction)
        {
            IMatlabSvc svcMatlab = (IMatlabSvc)this.getService(typeof(IMatlabSvc).Name);
            return svcMatlab.MatlabExecuteGradientDescent(X, y, theta, alpha, numInteraction);
        }
    }

   
}