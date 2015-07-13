using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewJobWebsite.Models.Mapping
{
    public class EmployerMap : EntityTypeConfiguration<Employer>
    {
        public EmployerMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployerId);

            // Properties
            this.Property(t => t.EmployerName)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Employer");
            this.Property(t => t.EmployerId).HasColumnName("EmployerId");
            this.Property(t => t.EmployerName).HasColumnName("EmployerName");
        }
    }
}
