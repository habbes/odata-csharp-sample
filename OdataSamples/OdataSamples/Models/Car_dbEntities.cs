using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OdataSamples.Models
{
    public class Car_dbEntities : DbContext
    {
        public Car_dbEntities() :
            base("name = Car_dbEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasRequired<CarModel>(c => c.CarModel);
            modelBuilder.Entity<Car>().HasRequired<CarColor>(c => c.CarColor);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public  DbSet<CarModel> CarModel { get; set; }
        public  DbSet<CarColor> CarColor { get; set; }
        public  DbSet<Car> Car { get; set; }
    }
}