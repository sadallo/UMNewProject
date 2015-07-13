using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class AgeDto
    {
        [DataMember]
        public string AgeId { get; set; }

        [DataMember]
        public string AgeDescription { get; set; }

        public static AgeDto createAgeDTO(Age obj)
        {
            AgeDto age = new AgeDto();
            age.AgeId = obj.AgeId;
            age.AgeDescription = obj.AgeDescription;
            return age;
        }

        public static AgeDto createAgeDTO(String AgeId, String AgeDescription)
        {
            AgeDto age = new AgeDto();
            age.AgeId = AgeId;
            age.AgeDescription = AgeDescription;
            return age;
        }
    }
}
