using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewJobWebsite.Models;
using UMNewJobWebsite.Service.Interface;
using UMNewJobWebsite.Exceptions.Service;

namespace UMNewJobWebsite.Business
{
    public class JobManager : BusinessManager
    {

        public List<Job> selectAllJob()
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectAllJob();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<Job> selectJobNotDoneByRecruiteeIdRecommendation(String recruiteeId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectJobNotDoneByRecruiteeIdRecommendation(recruiteeId);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<Job> selectJobIdNotDoneByRecruiteeId(String recruiteeId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectJobIdNotDoneByRecruiteeId(recruiteeId);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Job selectJobById(Job obj)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectJobById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertJob(Job obj)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.insertJob(obj);


            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateJob(Job obj)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.updateJob(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteJob(Job obj)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.deleteJob(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean addSkillToJob(Job obj, String skillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.addSkillToJob(obj, skillId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean removeSkillFromJob(Job obj, String skillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.removeSkillFromJob(obj, skillId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Job> selectJobBySkillId(String skillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectJobBySkillId(skillId);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Guid[] selectExpressionNames()
        {
           try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectExpressionNames();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }      
        }

        public double[] selectExpressionDifficulty()
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.selectExpressionDifficulty();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }
    }
}
