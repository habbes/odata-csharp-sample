using Microsoft.EntityFrameworkCore;

namespace StartupService.Models
{
    public class StartupDbContext: DbContext
    {
        public StartupDbContext(DbContextOptions<StartupDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var companyBuilder = modelBuilder.Entity<Company>();
            companyBuilder.OwnsOne(company => company.Location);
            companyBuilder.HasMany(company => company.Founders);
        }
    }
}