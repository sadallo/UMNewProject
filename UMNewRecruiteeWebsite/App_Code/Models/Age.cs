using System;
using System.Collections.Generic;

namespace UMNewRecruiteeWebsite.Models
{
    public partial class Age
    {
        public Age()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string AgeId { get; set; }
        public string AgeDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }
    }
}
