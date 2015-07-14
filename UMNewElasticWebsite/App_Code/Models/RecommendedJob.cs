using System;
using System.Collections.Generic;

namespace UMNewElasticWebsite.Models
{
    public partial class RecommendedJob
    {
        public System.Guid JobId { get; set; }
        public System.Guid RecruiteeId { get; set; }
        public decimal PredictedRankingValue { get; set; }

        public static RecommendedJob createRecommendedJob(Guid JobId, Guid RecruiteeId, decimal PredictedRankingValue)
        {
            RecommendedJob obj = new RecommendedJob();
            obj.JobId = JobId;
            obj.RecruiteeId = RecruiteeId;
            obj.PredictedRankingValue = PredictedRankingValue;
            return obj;
        }
    }
}
