using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewRecruiteeWebsite.Models.Mapping
{
    public class EducationMap : EntityTypeConfiguration<Education>
    {
        public EducationMap()
        {
            // Primary Key
            this.HasKey(t => t.EducationId);

            // Properties
            this.Property(t => t.EducationId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.EducationDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Education");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.EducationDescription).HasColumnName("EducationDescription");
        }
    }
}
