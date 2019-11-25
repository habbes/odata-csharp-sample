using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(db.Companies.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
            return Ok(company);
        }
    }
}