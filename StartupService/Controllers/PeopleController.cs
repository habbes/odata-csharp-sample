using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using StartupService.Models;

namespace StartupService.Controllers
{
    public class PeopleController: ODataController
    {
        private StartupDbContext db;

        public PeopleController(StartupDbContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(db.People);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(db.People.FirstOrDefault(p => p.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
            return Ok(person);
        }
    }
}