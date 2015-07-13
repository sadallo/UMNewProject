using System;
using System.Collections.Generic;

namespace UMNewRecruiteeWebsite.Models
{
    public partial class Education
    {
        public Education()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string EducationId { get; set; }
        public string EducationDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }
    }
}
