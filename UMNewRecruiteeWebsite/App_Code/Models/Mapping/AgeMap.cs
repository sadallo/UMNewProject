using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewRecruiteeWebsite.Models.Mapping
{
    public class AgeMap : EntityTypeConfiguration<Age>
    {
        public AgeMap()
        {
            // Primary Key
            this.HasKey(t => t.AgeId);

            // Properties
            this.Property(t => t.AgeId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.AgeDescription)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Age");
            this.Property(t => t.AgeId).HasColumnName("AgeId");
            this.Property(t => t.AgeDescription).HasColumnName("AgeDescription");
        }
    }
}
