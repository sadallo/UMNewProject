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

        public static Income createAge(String IncomeId, String IncomeDescription)
        {
            Income obj = new Income();
            obj.IncomeId = IncomeId;
            obj.IncomeDescription = IncomeDescription;
            return obj;
        }
    }
}
