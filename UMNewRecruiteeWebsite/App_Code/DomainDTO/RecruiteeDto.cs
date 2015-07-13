using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class RecruiteeDto
    {
        [DataMember]
        public System.Guid RecruiteeId { get; set; }

        [DataMember]
        public string RankingId { get; set; }

        [DataMember]
        public double RankingValue { get; set; }

        public static RecruiteeDto createRecruiteeDTO(Recruitee obj)
        {
            RecruiteeDto rec = new RecruiteeDto();
            rec.RecruiteeId = obj.RecruiteeId;
            rec.RankingId = obj.RankingId;
            rec.RankingValue = (double)obj.RankingValue;
            return rec;
        }

        public static RecruiteeDto createRecruiteeDTO(System.Guid RecruiteeId, String RankingId, double RankingValue)
        {
            RecruiteeDto rec = new RecruiteeDto();
            rec.RecruiteeId = RecruiteeId;
            rec.RankingId = RankingId;
            rec.RankingValue = (double)RankingValue;
            return rec;
        }
    }
}
