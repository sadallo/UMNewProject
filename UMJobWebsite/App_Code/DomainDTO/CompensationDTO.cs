using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMJobWebsite.Models;

namespace UMJobWebsite.DomainDTO
{
    [DataContract]
    public class CompensationDto
    {
        [DataMember]
        public string CompensationId { get; set; }

        [DataMember]
        public string CompensationType { get; set; }
        
        [DataMember]
        public string CompensationDescription { get; set; }

        public static CompensationDto createCompensationDTO(Compensation obj)
        {
            CompensationDto com = new CompensationDto();
            com.CompensationId = obj.CompensationId;
            com.CompensationType = obj.CompensationType;
            com.CompensationDescription = obj.CompensationDescription;
            return com;
        }

        public static CompensationDto createCompensationDTO(String CompensationId, String CompensationType, String CompensationDescription)
        {
            CompensationDto com = new CompensationDto();
            com.CompensationId = CompensationId;
            com.CompensationType = CompensationType;
            com.CompensationDescription = CompensationDescription;
            return com;
        }
    }
}