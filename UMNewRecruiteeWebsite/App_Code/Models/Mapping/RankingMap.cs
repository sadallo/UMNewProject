using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewRecruiteeWebsite.Models.Mapping
{
    public class RankingMap : EntityTypeConfiguration<Ranking>
    {
        public RankingMap()
        {
            // Primary Key
            this.HasKey(t => t.RankingId);

            // Properties
            this.Property(t => t.RankingId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.RankingName)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Ranking");
            this.Property(t => t.RankingId).HasColumnName("RankingId");
            this.Property(t => t.RankingName).HasColumnName("RankingName");
        }
    }
}
