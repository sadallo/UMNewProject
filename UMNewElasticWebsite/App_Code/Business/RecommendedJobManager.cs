using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;

namespace UMNewElasticWebsite.Business
{
    public class RecommendedJobManager : BusinessManager
    {

        public List<RecommendedJob> selectAllRecommendedJob()
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.selectAllRecommendedJob();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public RecommendedJob selectRecommendedJobByJobIdAndRecruiteeId(RecommendedJob obj)
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.selectRecommendedJobByJobIdAndRecruiteeId(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<RecommendedJob> selectRecommendedJobByRecruiteeId(RecommendedJob obj)
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.selectRecommendedJobByRecruiteeId(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertRecommendedJob(RecommendedJob obj)
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.insertRecommendedJob(obj);                   
              
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateRecommendedJob(RecommendedJob obj)
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.updateRecommendedJob(obj);
               
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteRecommendedJob(RecommendedJob obj)
        {
            try
            {
                IRecommendedJobSvc svc = (IRecommendedJobSvc)this.getService(typeof(IRecommendedJobSvc).Name);
                return svc.deleteRecommendedJob(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
