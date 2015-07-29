using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewJobWebsite.Models;

namespace UMNewJobWebsite.DomainDTO
{
    [DataContract]
    public class JobDto
    {
        [DataMember]
        public System.Guid JobId { get; set; }

        [DataMember]
        public string JobName { get; set; }

        [DataMember]
        public string CompensationId { get; set; }

        [DataMember]
        public System.Guid EmployerId { get; set; }

        [DataMember]
        public string JobDescription { get; set; }

        [DataMember]
        public int JobQuota { get; set; }

        [DataMember]
        public double JobExperienceLevel { get; set; }

        [DataMember]
        public double JobCompensationValue { get; set; }

        public static JobDto createJobDTO(Job obj)
        {
            JobDto job = new JobDto();
            job.JobId = obj.JobId;
            job.JobName = obj.JobName;
            job.CompensationId = obj.CompensationId;
            job.EmployerId = obj.EmployerId;
            job.JobDescription = obj.JobDescription;
            job.JobQuota = obj.JobQuota;
            job.JobExperienceLevel = (double)obj.JobExperienceLevel;
            job.JobCompensationValue = (double)obj.JobCompensationValue;
            return job;
        }

        public static JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, double JobExperienceLevel, double JobCompensationValue)
        {
            JobDto job = new JobDto();
            job.JobId = JobId;
            job.JobName = JobName;
            job.CompensationId = CompensationId;
            job.EmployerId = EmployerId;
            job.JobDescription = JobDescription;
            job.JobQuota = JobQuota;
            job.JobExperienceLevel = JobExperienceLevel;
            job.JobCompensationValue = JobCompensationValue;
            return job;
        }
    }
}