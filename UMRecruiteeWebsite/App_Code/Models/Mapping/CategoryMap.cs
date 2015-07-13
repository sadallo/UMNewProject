using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMRecruiteeWebsite.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.CategoryId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CategoryDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryDescription).HasColumnName("CategoryDescription");

            // Relationships
            this.HasMany(t => t.Recruitees)
                .WithMany(t => t.Categories)
                .Map(m =>
                    {
                        m.ToTable("RecruiteeCategory");
                        m.MapLeftKey("CategoryId");
                        m.MapRightKey("RecruiteeId");
                    });


        }
    }
}
