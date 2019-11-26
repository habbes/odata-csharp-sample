using Default;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.OData.Client;
using StartupService.Models;

namespace StartupClient
{
    class Program
    {

        static Container container = new Container(new Uri("http://localhost:5000/odata"));

        static async Task Main(string[] args)
        {
            await InteractWithService();
        }

        static async Task InteractWithService()
        {
            var query = container.Companies.Where(c => c.YearFounded < 2000) as DataServiceQuery<Company>;
            var companies = (await query.ExecuteAsync()).ToList();
            foreach (var company in companies.Where(c => c.YearFounded < 2000))
            {
                DisplayCompany(company);
                Console.WriteLine();
            }
            
            var newCompany = new Company
            {
                Id = 100,
                Name = "Acme",
                Type = CompanyType.Public,
                YearFounded = 2008,
                Location = new Address { City = "Mombasa", Country = "Kenya" }
            };
            container.AddToCompanies(newCompany);
            await container.SaveChangesAsync();
        }

        static void DisplayCompany(Company company)
        {
            Console.WriteLine(company.Name);
            Console.WriteLine("Location: {0}, {1}", company.Location.City, company.Location.Country);
            Console.WriteLine("Type: {0}", company.Type.ToString());
            Console.WriteLine("Founded: {0}", company.YearFounded);
            if (company.Founders != null)
            {
                Console.Write("Founders:");
                foreach (var founder in company.Founders)
                {
                    Console.Write(" {0},", founder.Name);
                }
            }
            Console.WriteLine();
        }
    }


}
