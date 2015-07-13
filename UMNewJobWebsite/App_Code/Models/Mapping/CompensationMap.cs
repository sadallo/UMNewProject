using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewJobWebsite.Models.Mapping
{
    public class CompensationMap : EntityTypeConfiguration<Compensation>
    {
        public CompensationMap()
        {
            // Primary Key
            this.HasKey(t => t.CompensationId);

            // Properties
            this.Property(t => t.CompensationId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.CompensationType)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CompensationDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Compensation");
            this.Property(t => t.CompensationId).HasColumnName("CompensationId");
            this.Property(t => t.CompensationType).HasColumnName("CompensationType");
            this.Property(t => t.CompensationDescription).HasColumnName("CompensationDescription");
        }
    }
}
