using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupService.Models;

namespace StartupService.Controllers
{
    public class CompaniesController: ODataController
    {
        private StartupDbContext db;

        public CompaniesController(StartupDbContext dbContext)
        {
            this.db = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(db.Companies);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var company = db.Companies.FirstOrDefault(c => c.Id == key);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            try
            {
                db.Companies.Add(company);
                await db.SaveChangesAsync();
                return Created(company);
            }
            catch
            {
                db.Companies.Local.Remove(company);
                return BadRequest();
            }
        }

        [EnableQuery]
        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<Company> delta)
        {
            var company = db.Companies.FirstOrDefault(c => c.Id == key);
            if (company == null)
            {
                return NotFound();
            }
            delta.Patch(company);
            await db.SaveChangesAsync();
            return Updated(company);
        }

        [EnableQuery]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Company company)
        {
            if (key != company.Id)
            {
                return BadRequest();
            }
            db.Entry(company).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Updated(company);
        }

        [EnableQuery]
        public async Task<IActionResult> Delete(int key)
        {
            var company = db.Companies.FirstOrDefault(c => c.Id == key);
            if (company == null)
            {
                return NotFound();
            }
            db.Remove(company);
            await db.SaveChangesAsync();
            return Ok(company);
        }

        [HttpGet]
        [ODataRoute("MostPopularLocationInPeriod(startYear={startYear},endYear={endYear})")]
        public IActionResult MostPopularLocationInPeriod([FromODataUri] int startYear, [FromODataUri] int endYear)
        {
            var companies = db.Companies.Where(c => c.YearFounded >= startYear && c.YearFounded <= endYear);
            var mostHits = 0;
            Address result = null;
            var locationCounts = new Dictionary<string, int>();
            foreach (var company in companies)
            {
                var locationKey = company.Location.ToString();
                var value = 0;
                locationCounts.TryGetValue(locationKey, out value);
                var newValue = value + 1;
                locationCounts[locationKey] = newValue;

                if (newValue > mostHits)
                {
                    mostHits = newValue;
                    result = company.Location;
                }
            }

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> MakePublic(ODataActionParameters parameters)
        {
            int key = (int) parameters["company"];
            var company = db.Companies.FirstOrDefault(c => c.Id == key);
            if (company == null)
            {
                return NotFound();
            }
            if (company.Type == CompanyType.Public)
            {
                return BadRequest("The selected company is already public.");
            }
            company.Type = CompanyType.Public;
            db.Entry(company).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(company);
        }
    }
}