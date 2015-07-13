using System;
using System.Collections.Generic;

namespace UMJobWebsite.Models
{
    public class Compensation
    {
        public Compensation()
        {
            this.Jobs = new List<Job>();
        }

        public string CompensationId { get; set; }
        public string CompensationType { get; set; }
        public string CompensationDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }


        public static Compensation createCompensation(String CompensationId, String CompensationType, String CompensationDescription)
        {
            Compensation obj = new Compensation();
            obj.CompensationId = CompensationId;
            obj.CompensationType = CompensationType;
            obj.CompensationDescription = CompensationDescription;
            return obj;
        }
    }
}
