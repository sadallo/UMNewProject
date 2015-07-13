using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewRecruiteeWebsite.Models.Mapping
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

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FirstName)
                .HasMaxLength(30);

            this.Property(t => t.LastName)
                .HasMaxLength(30);

            this.Property(t => t.Gender)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.AgeId)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.EducationId)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.IncomeId)
                .IsFixedLength()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Recruitee");
            this.Property(t => t.RecruiteeId).HasColumnName("RecruiteeId");
            this.Property(t => t.RankingId).HasColumnName("RankingId");
            this.Property(t => t.RankingValue).HasColumnName("RankingValue");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.AgeId).HasColumnName("AgeId");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.IncomeId).HasColumnName("IncomeId");

            // Relationships
            this.HasMany(t => t.Skills)
                .WithMany(t => t.Recruitees)
                .Map(m =>
                    {
                        m.ToTable("RecruiteeSkill");
                        m.MapLeftKey("RecruiteeId");
                        m.MapRightKey("SkillId");
                    });

            this.HasOptional(t => t.Age)
                .WithMany(t => t.Recruitees)
                .HasForeignKey(d => d.AgeId);
            this.HasOptional(t => t.Education)
                .WithMany(t => t.Recruitees)
                .HasForeignKey(d => d.EducationId);
            this.HasOptional(t => t.Income)
                .WithMany(t => t.Recruitees)
                .HasForeignKey(d => d.IncomeId);
            this.HasOptional(t => t.Ranking)
                .WithMany(t => t.Recruitees)
                .HasForeignKey(d => d.RankingId);

        }
    }
}
