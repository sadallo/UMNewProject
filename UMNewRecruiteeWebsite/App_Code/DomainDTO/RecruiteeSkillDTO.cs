using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class RecruiteeSkillDto
    {
        [DataMember]
        public Guid RecruiteeId { get; set; }

        [DataMember]
        public String SkillId { get; set; }


        public static RecruiteeSkillDto createRecruiteeSkillDTO(String RecruiteeId, String SkillId)
        {
            RecruiteeSkillDto RecruiteeSkill = new RecruiteeSkillDto();
            RecruiteeSkill.RecruiteeId = new Guid(RecruiteeId);
            RecruiteeSkill.SkillId = SkillId;
            return RecruiteeSkill;
        }
    }
}
