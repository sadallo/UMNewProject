using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class IncomeDto
    {
        [DataMember]
        public string IncomeId { get; set; }

        [DataMember]
        public string IncomeDescription { get; set; }

        public static IncomeDto createIncomeDTO(Income obj)
        {
            IncomeDto inc = new IncomeDto();
            inc.IncomeId = obj.IncomeId;
            inc.IncomeDescription = obj.IncomeDescription;
            return inc;
        }

        public static IncomeDto createIncomeDTO(String IncomeId, String IncomeDescription)
        {
            IncomeDto inc = new IncomeDto();
            inc.IncomeId = IncomeId;
            inc.IncomeDescription = IncomeDescription;
            return inc;
        }
    }
}
