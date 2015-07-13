using System;
using System.Collections.Generic;

namespace UMRecruiteeWebsite.Models
{
    public class Skill
    {
        public Skill()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }

        public static Skill createSkill(String SkillId, String SkillName, String SkillDescription)
        {
            Skill obj = new Skill();
            obj.SkillId = SkillId;
            obj.SkillName = SkillName;
            obj.SkillDescription = SkillDescription;
            return obj;
        }
    }
}
