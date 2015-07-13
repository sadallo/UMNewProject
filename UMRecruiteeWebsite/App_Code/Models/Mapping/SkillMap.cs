using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMRecruiteeWebsite.Models.Mapping
{
    public class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            // Primary Key
            this.HasKey(t => t.SkillId);

            // Properties
            this.Property(t => t.SkillId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.SkillName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SkillDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Skill");
            this.Property(t => t.SkillId).HasColumnName("SkillId");
            this.Property(t => t.SkillName).HasColumnName("SkillName");
            this.Property(t => t.SkillDescription).HasColumnName("SkillDescription");
        }
    }
}
