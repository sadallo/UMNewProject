using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UMNewJobWebsite.Models.Mapping;

namespace UMNewJobWebsite.Models
{
    public class NewJobBankContext : DbContext
    {
        static NewJobBankContext()
        {
            Database.SetInitializer<NewJobBankContext>(null);
        }

        public NewJobBankContext()
            : base("Name=NewJobBankContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CompensationMap());
            modelBuilder.Configurations.Add(new EmployerMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());

            // Fixes Sql precision problem  TABLE: Job COLUMN: JobCompensationValue
            modelBuilder.Entity<Job>().Property(x => x.JobCompensationValue).HasPrecision(18, 2);

            // Fixes Sql precision problem  TABLE: Job COLUMN: JobExperienceLevel
            modelBuilder.Entity<Job>().Property(x => x.JobExperienceLevel).HasPrecision(5, 3);
        }
    }
}
