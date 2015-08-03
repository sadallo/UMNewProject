using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.DomainDTO;
using UMNewElasticWebsite.Domain;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;


namespace UMNewElasticWebsite.Business
{
    public class ElasticManager : BusinessManager
    {

        public bool insertRecommenderJob(DataResult avgs)
        {
            try
            {
                IElasticSvc svc = (IElasticSvc)this.getService(typeof(IElasticSvc).Name);
                return svc.insertRecommenderJob(avgs);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }

        }
        public double[,] SelectRatings(String[] expressions, UserProfile[] users)
        {
            try
            {
                IElasticSvc svc = (IElasticSvc)this.getService(typeof(IElasticSvc).Name);
                return svc.SelectRatings(expressions, users);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }

        }

        public bool InsertRatings(String[] expressions, UserProfile[] users, double[,] Y)
        {
            try
            {
                IElasticSvc svc = (IElasticSvc)this.getService(typeof(IElasticSvc).Name);
                return svc.InsertRatings(expressions, users, Y);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }

        }

        public int[,] GetYIndex(String jobID, String recruiteeID, String[] expressions, UserProfile[] users)
        {
            try
            {
                IElasticSvc svc = (IElasticSvc)this.getService(typeof(IElasticSvc).Name);
                return svc.GetYIndex(jobID, recruiteeID, expressions, users);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }

        }

        
    }
}
