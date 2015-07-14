using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UMNewRecruiteeWebsite.Models.Mapping;

namespace UMNewRecruiteeWebsite.Models
{
    public class NewRecruiteeBankContext : DbContext
    {
        static NewRecruiteeBankContext()
        {
            Database.SetInitializer<NewRecruiteeBankContext>(null);
        }

        public NewRecruiteeBankContext()
            : base("Name=NewRecruiteeBankContext")
        {
        }

        public DbSet<Age> Ages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Recruitee> Recruitees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgeMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new EducationMap());
            modelBuilder.Configurations.Add(new IncomeMap());
            modelBuilder.Configurations.Add(new RankingMap());
            modelBuilder.Configurations.Add(new RecruiteeMap());
            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());

            // Fixes Sql precision problem  TABLE: Recruitee COLUMN: RankingValue
            modelBuilder.Entity<Recruitee>().Property(x => x.RankingValue).HasPrecision(18, 14);
        }
    }
}
