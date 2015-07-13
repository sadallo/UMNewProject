using System;
using System.Collections.Generic;

namespace UMNewJobWebsite.Models
{
    public class Job
    {
        public Job()
        {
            this.Categories = new List<Category>();
	        this.Skills = new List<Skill>();
        }

        public System.Guid JobId { get; set; }
        public string JobName { get; set; }
        public string CompensationId { get; set; }
        public System.Guid EmployerId { get; set; }
        public string JobDescription { get; set; }
        public int JobQuota { get; set; }
        public string JobExperienceLevel { get; set; }
        public decimal JobCompensationValue { get; set; }
        public virtual Compensation Compensation { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
	    public virtual ICollection<Skill> Skills { get; set; }

        public static Job createJob(System.Guid JobId, String JobName, String CompensationId, System.Guid EmployerId, 
                                    String JobDescription, int JobQuota, String JobExperienceLevel, decimal JobCompensationValue)
        {
            Job obj = new Job();
            obj.JobId = JobId;
            obj.JobName = JobName;
            obj.CompensationId = CompensationId;
            obj.EmployerId = EmployerId;
            obj.JobDescription = JobDescription;
            obj.JobQuota = JobQuota;
            obj.JobExperienceLevel = JobExperienceLevel;
            obj.JobCompensationValue = JobCompensationValue;
            return obj;
        }


        
    }
}
