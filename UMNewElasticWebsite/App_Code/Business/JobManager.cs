using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using NewJobService;

namespace UMNewElasticWebsite.Business
{
    public class JobManager : BusinessManager
    {

        public List<JobDto> selectAllJob()
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                List<JobDto> list = svc.selectAllJob();
                return list;
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public JobDto selectJobById(JobDto obj)
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

        public Boolean insertJob(JobDto obj)
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

        public Boolean updateJob(JobDto obj)
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

        public Boolean deleteJob(JobDto obj)
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

        public JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
            }
            catch(ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<JobDto> selectJobBySkillId(String SkillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                List<JobDto> list = svc.selectJobBySkillId(SkillId);
                return list;
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean addSkillToJob(JobDto obj, String SkillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.addSkillToJob(obj, SkillId);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean removeSkillFromJob(JobDto obj, String SkillId)
        {
            try
            {
                IJobSvc svc = (IJobSvc)this.getService(typeof(IJobSvc).Name);
                return svc.removeSkillFromJob(obj, SkillId);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
       
}
