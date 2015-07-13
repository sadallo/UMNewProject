using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMRecruiteeWebsite.Models.Mapping
{
    public class RecruiteeMap : EntityTypeConfiguration<Recruitee>
    {
        public RecruiteeMap()
        {
            // Primary Key
            this.HasKey(t => t.RecruiteeId);

            // Properties
            this.Property(t => t.RankingId)
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Recruitee");
            this.Property(t => t.RecruiteeId).HasColumnName("RecruiteeId");
            this.Property(t => t.RankingId).HasColumnName("RankingId");
            this.Property(t => t.RankingValue).HasColumnName("RankingValue");

            // Relationships
            this.HasMany(t => t.Skills)
                .WithMany(t => t.Recruitees)
                .Map(m =>
                {
                    m.ToTable("RecruiteeSkill");
                    m.MapLeftKey("RecruiteeId");
                    m.MapRightKey("SkillId");
                });

            this.HasOptional(t => t.Ranking)
                .WithMany(t => t.Recruitees)
                .HasForeignKey(d => d.RankingId);

        }
    }
}
