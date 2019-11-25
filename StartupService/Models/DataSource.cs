using System.Linq;

namespace StartupService.Models
{
    public static class DataSource
    {
        public static void SeedDatabase(StartupDbContext db)
        {
            db.Database.EnsureCreated();
            if (db.People.Any())
            {
                return;
            }
            db.People.Add(new Person
            {
                Id = 1,
                Name = "Sam Gikandi"
            });
            db.People.Add(new Person
            {
                Id = 2,
                Name = "Bill Gates"
            });
            db.People.Add(new Person
            {
                Id = 3,
                Name = "Paul Allen"
            });
            db.People.Add(new Person
            {
                Id = 4,
                Name = "Sridhar Vembu"
            });
            db.SaveChanges();

            db.Companies.Add(new Company
            {
                Id = 1,
                Name = "Africa's Talking",
                Location = new Address { City = "Nairobi", Country = "Kenya" },
                YearFounded = 2010,
                Type = CompanyType.Private,
                Founders = db.People.Where(p => p.Name.Contains("Sam")).ToList()
            });
            db.Companies.Add(new Company
            {
                Id = 2,
                Name = "Microsoft",
                Location = new Address { City = "Redmond", Country = "United States" },
                YearFounded = 1975,
                Type = CompanyType.Public,
                Founders = db.People.Where(p => p.Name.Contains("Gates") || p.Name.Contains("Allen")).ToList()
            });
            db.Companies.Add(new Company
            {
                Id = 3,
                Name = "Zoho",
                Location = new Address { City = "Chennai", Country = "India" },
                YearFounded = 1996,
                Type = CompanyType.Private,
                Founders = db.People.Where(p => p.Name.Contains("Vembu")).ToList()
            });
            db.SaveChanges();
        }
    }
}