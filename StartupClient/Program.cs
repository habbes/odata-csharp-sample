using Default;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.OData.Client;
using StartupService.Models;

namespace StartupClient
{
    class Program
    {

        static Container container = new Container(new Uri("http://localhost:5000/odata"));

        static async Task Main(string[] args)
        {
            //await InteractWithService();
            //var companies = await container.Companies.Expand("Founders").ExecuteAsync();
            //Console.WriteLine("{0}Final company list:{0}", Environment.NewLine);

            //foreach (var company in companies)
            //{
            //    DisplayCompany(company);
            //    Console.WriteLine();
            //}

            await TestFunction();
        }

        static async Task TestFunction()
        {
            var param = new List<DummyType>();
            param.AddRange(new DummyType[] {
                new DummyType { Foo = 1, Bar = 2 },
                new DummyType { Foo = 2, Bar = 4 }
            });
            var response = await container.DummyFunc(param).GetValueAsync();
            Console.WriteLine("Function result {0}", response);
        }

        static async Task InteractWithService()
        {
            var query = container.Companies.Expand("Founders")
                .Where(c => c.YearFounded < 2000) as DataServiceQuery<Company>;
            var companies = (await query.ExecuteAsync()).ToList();
            foreach (var company in companies.Where(c => c.YearFounded < 2000))
            {
                DisplayCompany(company);
                Console.WriteLine();
            }

            var ms = companies.FirstOrDefault(c => c.Name == "Microsoft");
            if (ms != null)
            {
                ms.Name = "Microsoft Corporation";
                container.UpdateObject(ms);
                await container.SaveChangesAsync();
                DisplayCompany(ms, "Updated Microsoft");
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
            DisplayCompany(newCompany, "Added new company...");

            var toDelete = companies.FirstOrDefault(c => c.Type == CompanyType.Private);
            if (toDelete != null)
            {
                container.DeleteObject(toDelete);
                await container.SaveChangesAsync();
                DisplayCompany(toDelete, "Removed company");
            }

        }

        static void DisplayCompany(Company company, string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
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
