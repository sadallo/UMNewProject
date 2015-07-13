using System;
using System.Collections.Generic;

namespace UMNewJobWebsite.Models
{
    public class Employer
    {
        public Employer()
        {
            this.Jobs = new List<Job>();
        }

        public System.Guid EmployerId { get; set; }
        public string EmployerName { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

        public static Employer createEmployer(System.Guid EmployerId, String EmployerName)
        {
            Employer obj = new Employer();
            obj.EmployerId = EmployerId;
            obj.EmployerName = EmployerName;
            return obj;
        }
    }
}
