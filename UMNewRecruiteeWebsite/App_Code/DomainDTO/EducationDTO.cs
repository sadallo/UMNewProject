using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class EducationDto
    {
        [DataMember]
        public string EducationId { get; set; }

        [DataMember]
        public string EducationDescription { get; set; }

        public static EducationDto createEducationDTO(Education obj)
        {
            EducationDto edu = new EducationDto();
            edu.EducationId = obj.EducationId;
            edu.EducationDescription = obj.EducationDescription;
            return edu;
        }

        public static EducationDto createEducationDTO(String EducationId, String EducationDescription)
        {
            EducationDto edu = new EducationDto();
            edu.EducationId = EducationId;
            edu.EducationDescription = EducationDescription;
            return edu;
        }
    }
}
