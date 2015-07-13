using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMRecruiteeWebsite.Models;

namespace UMRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class RankingDto
    {
        [DataMember]
        public string RankingId { get; set; }

        [DataMember]
        public string RankingName { get; set; }


        public static RankingDto createRankingDTO(Ranking obj)
        {
            RankingDto ran = new RankingDto();
            ran.RankingId = obj.RankingId;
            ran.RankingName = obj.RankingName;
            return ran;
        }

        public static RankingDto createRankingDTO(String RankingId, String RankingName)
        {
            RankingDto ran = new RankingDto();
            ran.RankingId = RankingId;
            ran.RankingName = RankingName;
            return ran;
        }
    }
}
