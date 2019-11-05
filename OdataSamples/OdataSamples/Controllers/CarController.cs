using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.OData;
using OdataSamples.Models;

namespace OdataSamples.Controllers
{
    public class CarController : ODataController
    {
        Car_dbEntities car_db = new Car_dbEntities();

        [EnableQuery]
        public IQueryable<Car> Get()
        {

            return car_db.Car;
        }

        [EnableQuery]
        public SingleResult<Car> Get([FromODataUri] int key)
        {
            IQueryable<Car> result = car_db.Car.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
        [EnableQuery]
        public SingleResult<CarModel> GetCarModel([FromODataUri] int key)
        {
            IQueryable<CarModel> result = car_db.Car.Where(p => p.Id == key).Select(c => c.CarModel);
            return SingleResult.Create(result);
        }
        [EnableQuery]
        public SingleResult<CarColor> GetCarColor([FromODataUri] int key)
        {
            IQueryable<CarColor> result = car_db.Car.Where(p => p.Id == key).Select(c => c.CarColor);
            return SingleResult.Create(result);
        }

        public IHttpActionResult Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                car_db.Car.Add(car);
                car_db.SaveChanges();
                return Created(car);
            }
            catch (Exception xx)
            {
                return BadRequest(xx.Message);

            }

        }


        public IHttpActionResult Patch([FromODataUri] int key, Delta<Car> car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = car_db.Car.Find(key);
            if (entity == null)
            {
                return NotFound();
            }
            car.Patch(entity);
            try
            {
                car_db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!CarExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        private bool CarExists(int key)
        {
            return car_db.Car.Any(n=>n.Id == key);        
        }

        public IHttpActionResult Put([FromODataUri] int key, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != car.Id)
            {
                return BadRequest();
            }
            car_db.Entry(car).State = EntityState.Modified;
            try
            {
                car_db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (!CarExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(car);
        }


        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var car = car_db.Car.Find(key);
            if (car == null)
            {
                return NotFound();
            }
            car_db.Car.Remove(car);
            car_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpGet]
        public IHttpActionResult ModelWithHighestCarValue()
        {
            var car = car_db.Car.OrderByDescending(a => a.CarValue).Select(a => a.CarModel.ModelName).FirstOrDefault();

            return Ok(car);
        }

        [HttpGet]
        public IHttpActionResult MostLikedCarColor()
        {
            List<CarColor> getCarColorIds = new List<CarColor>();

            getCarColorIds = car_db.CarColor.ToList();

            Dictionary<string, int> ColorOccurencesDict = new Dictionary<string, int>();

            foreach (var colorId in getCarColorIds) {
                var ColorOccurence = car_db.Car.Where(a => a.CarColorId == colorId.Id).Count();
                ColorOccurencesDict.Add(colorId.ColorName, ColorOccurence);
            }

            string MostLikedColor = ColorOccurencesDict.OrderByDescending(x => x.Value).First().Key;


            return Ok(MostLikedColor);
        }


        [HttpGet]
        public IHttpActionResult HighestCarValue()
        {
            var car = car_db.Car.Max(a => a.CarValue);
            return Ok(car);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CarValueUpdate([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            double CarValue = (double)parameters["CarValue"];
            var entity = car_db.Car.Find(key);

            if (entity == null) {
                return BadRequest();          
            }
            entity.CarValue = CarValue;
           
            try
            {
                await car_db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (!CarExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
