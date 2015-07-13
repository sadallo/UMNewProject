using System;
using System.Collections.Generic;

namespace UMNewRecruiteeWebsite.Models
{
    public class Recruitee
    {
        public Recruitee()
        {
            this.Categories = new List<Category>();
            this.Skills = new List<Skill>();
        }

        public System.Guid RecruiteeId { get; set; }
        public string RankingId { get; set; }
        public decimal RankingValue { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AgeId { get; set; }
        public string EducationId { get; set; }
        public string IncomeId { get; set; }
        public virtual Age Age { get; set; }
        public virtual Education Education { get; set; }
        public virtual Income Income { get; set; }
        public virtual Ranking Ranking { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

        public static Recruitee createRecruitee(System.Guid RecruiteeId, String RankingId, decimal RankingValue)
        {
            Recruitee obj = new Recruitee();
            obj.RecruiteeId = RecruiteeId;
            obj.RankingId = RankingId;
            obj.RankingValue = RankingValue;
            return obj;
        }
    }
}
