using System;
using System.Collections.Generic;

namespace UMRecruiteeWebsite.Models
{
    public class Ranking
    {
        public Ranking()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string RankingId { get; set; }
        public string RankingName { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }

        public static Ranking createRanking(String RankingId, String RankingName)
        {
            Ranking obj = new Ranking();
            obj.RankingId = RankingId;
            obj.RankingName = RankingName;
            return obj;
        }
    }
}
