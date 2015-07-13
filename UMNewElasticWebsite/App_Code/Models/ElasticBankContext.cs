using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UMNewElasticWebsite.Models.Mapping;

namespace UMNewElasticWebsite.Models
{
    public partial class ElasticBankContext : DbContext
    {
        static ElasticBankContext()
        {
            Database.SetInitializer<ElasticBankContext>(null);
        }

        public ElasticBankContext()
            : base("Name=ElasticBankContext")
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskMap());
        }
    }
}
