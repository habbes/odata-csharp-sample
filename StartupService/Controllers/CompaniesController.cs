using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
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
            db.Companies.Add(company);
            await db.SaveChangesAsync();
            return Created(company);
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
    }
}