using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UMNewElasticWebsite.Models.Mapping;

namespace UMNewElasticWebsite.Models
{
    public partial class NewElasticBankContext : DbContext
    {
        static NewElasticBankContext()
        {
            Database.SetInitializer<NewElasticBankContext>(null);
        }

        public NewElasticBankContext()
            : base("Name=NewElasticBankContext")
        {
        }

        public DbSet<RecommendedJob> RecommendedJobs { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RecommendedJobMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TaskMap());
        }
    }
}
