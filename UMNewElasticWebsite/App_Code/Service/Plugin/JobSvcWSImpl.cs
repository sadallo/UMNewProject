using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJobService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class JobSvcWSImpl : IJobSvc
    {
        public List<JobDto> selectAllJob()
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();
           
            try
            {
                return svc.selectAllJob().ToList<JobDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public JobDto selectJobById(JobDto obj)
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

            try
            {
                return svc.selectJobById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertJob(JobDto obj)
        {
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                try
                {                        
                    return svc.insertJob(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateJob(JobDto obj)
        {
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                try
                {
                    JobDto rec = svc.selectJobById(obj);

                    if (rec != null)
                    {
                        return svc.updateJob(obj);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean deleteJob(JobDto obj)
        {
            using (NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                try
                {
                    JobDto rec = svc.selectJobById(obj);

                    if (rec != null)
                    {
                        return svc.deleteJob(obj);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public JobDto createJobDTO(Guid JobId, String JobName, String CompensationId, Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
        {
            using(NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient())
            {
                return svc.createJobDTO(JobId, JobName, CompensationId, EmployerId, JobDescription, JobQuota, JobExperienceLevel, JobCompensationValue);
            }
        }

        public List<JobDto> selectJobBySkillId(String SkillId)
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

            try
            {
                return svc.selectJobBySkillId(SkillId).ToList<JobDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean addSkillToJob(JobDto obj, String skillId)
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

            try
            {
                return svc.addSkillToJob(obj.JobId, skillId);
            }
            catch
            {
                return false;
            }

        }

        public Boolean removeSkillFromJob(JobDto obj, String skillId)
        {
            NewJobService.ServiceWCFClient svc = new NewJobService.ServiceWCFClient();

            try
            {
                return svc.removeSkillFromJob(obj.JobId, skillId);
            }
            catch
            {
                return false;
            }

        }
    }
}