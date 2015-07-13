using System;
using System.Collections.Generic;

namespace UMNewRecruiteeWebsite.Models
{
    public partial class Income
    {
        public Income()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string IncomeId { get; set; }
        public string IncomeDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }
    }
}
