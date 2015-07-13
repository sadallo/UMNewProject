using System;
using System.Collections.Generic;

namespace UMNewRecruiteeWebsite.Models
{
    public class Age
    {
        public Age()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string AgeId { get; set; }
        public string AgeDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }

        public static Age createAge(String AgeId, String AgeDescription)
        {
            Age obj = new Age();
            obj.AgeId = AgeId;
            obj.AgeDescription = AgeDescription;
            return obj;
        }
    }
}
