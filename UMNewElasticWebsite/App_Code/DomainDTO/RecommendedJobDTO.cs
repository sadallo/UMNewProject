using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UMNewElasticWebsite.Models;

namespace UMNewElasticWebsite.DomainDTO
{
    [DataContract]
    public class RecommendedJobDto
    {
        [DataMember]
        public Guid JobId { get; set; }

        [DataMember]
        public Guid RecruiteeId { get; set; }

        [DataMember]
        public double PredictedRankingValue { get; set; }


        public static RecommendedJobDto createRecommendedJobDTO(RecommendedJob obj)
        {
            RecommendedJobDto task = new RecommendedJobDto();
            task.JobId = obj.JobId;
            task.RecruiteeId = obj.RecruiteeId;
            task.PredictedRankingValue = (double)obj.PredictedRankingValue;
            return task;
        }

        public static RecommendedJobDto createRecommendedJobDTO(Guid JobId, Guid RecruiteeId, decimal PredictedRankingValue)
        {
            RecommendedJobDto task = new RecommendedJobDto();
            task.JobId = JobId;
            task.RecruiteeId = RecruiteeId;
            task.PredictedRankingValue = (double)PredictedRankingValue;
            return task;
        }
    }
}