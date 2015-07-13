using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMJobWebsite.Models;
using UMJobWebsite.Service.Interface;
using UMJobWebsite.Exceptions.Service;

namespace UMJobWebsite.Business
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
    }
}
