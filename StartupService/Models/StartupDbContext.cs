using Microsoft.EntityFrameworkCore;

namespace StartupService.Models
{
    public class StartupDbContext: DbContext
    {
        public StartupDbContext(DbContextOptions<StartupDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies;
        public DbSet<Person> People;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().OwnsOne(company => company.Location);
        }
    }
}