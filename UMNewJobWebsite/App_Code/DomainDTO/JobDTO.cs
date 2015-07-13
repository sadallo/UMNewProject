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
        public string JobExperienceLevel { get; set; }

        [DataMember]
        public decimal JobCompensationValue { get; set; }

        public static JobDto createJobDTO(Job obj)
        {
            JobDto job = new JobDto();
            job.JobId = obj.JobId;
            job.JobName = obj.JobName;
            job.CompensationId = obj.CompensationId;
            job.EmployerId = obj.EmployerId;
            job.JobDescription = obj.JobDescription;
            job.JobQuota = obj.JobQuota;
            job.JobExperienceLevel = obj.JobExperienceLevel;
            job.JobCompensationValue = obj.JobCompensationValue;
            return job;
        }

        public static JobDto createJobDTO(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId,
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
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