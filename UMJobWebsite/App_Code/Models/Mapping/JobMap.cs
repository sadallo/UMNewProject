using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMJobWebsite.Models.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties
            this.Property(t => t.JobName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CompensationId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.JobDescription)
                .HasMaxLength(100);

            this.Property(t => t.JobExperienceLevel)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Job");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.JobName).HasColumnName("JobName");
            this.Property(t => t.CompensationId).HasColumnName("CompensationId");
            this.Property(t => t.EmployerId).HasColumnName("EmployerId");
            this.Property(t => t.JobDescription).HasColumnName("JobDescription");
            this.Property(t => t.JobQuota).HasColumnName("JobQuota");
            this.Property(t => t.JobExperienceLevel).HasColumnName("JobExperienceLevel");
            this.Property(t => t.JobCompensationValue).HasColumnName("JobCompensationValue");

            // Relationships
            this.HasMany(t => t.Skills)
                .WithMany(t => t.Jobs)
                .Map(m =>
                    {
                        m.ToTable("JobSkill");
                        m.MapLeftKey("JobId");
                        m.MapRightKey("SkillId");
                    });

            this.HasRequired(t => t.Compensation)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.CompensationId);
            this.HasRequired(t => t.Employer)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.EmployerId);

        }
    }
}
