using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewRecruiteeWebsite.Models.Mapping
{
    public class IncomeMap : EntityTypeConfiguration<Income>
    {
        public IncomeMap()
        {
            // Primary Key
            this.HasKey(t => t.IncomeId);

            // Properties
            this.Property(t => t.IncomeId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.IncomeDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Income");
            this.Property(t => t.IncomeId).HasColumnName("IncomeId");
            this.Property(t => t.IncomeDescription).HasColumnName("IncomeDescription");
        }
    }
}
