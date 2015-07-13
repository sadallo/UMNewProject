using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace UMNewElasticWebsite.Models.Mapping
{
    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.TaskId);

            // Properties
            this.Property(t => t.TaskDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Task");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.RecruiteeId).HasColumnName("RecruiteeId");
            this.Property(t => t.TaskDescription).HasColumnName("TaskDescription");
        }
    }
}
