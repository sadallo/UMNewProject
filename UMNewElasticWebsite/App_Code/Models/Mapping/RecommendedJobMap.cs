using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewElasticWebsite.Models.Mapping
{
    public class RecommendedJobMap : EntityTypeConfiguration<RecommendedJob>
    {
        public RecommendedJobMap()
        {
            // Primary Key
            this.HasKey(t => new { t.JobId, t.RecruiteeId });

            // Properties
            // Table & Column Mappings
            this.ToTable("RecommendedJob");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.RecruiteeId).HasColumnName("RecruiteeId");
            this.Property(t => t.PredictedRankingValue).HasColumnName("PredictedRankingValue");
        }
    }
}
