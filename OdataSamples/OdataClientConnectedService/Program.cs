using Default;
using OdataSamples.Models;
using System;
using System.Linq;

namespace OdataClientConnectedService
{
    class Program
    {
        static void GetAllCars(Container container)
        {
            //var cars = container.Car;
            var cars = from car in container.Car
                       select car;
            foreach (var car in cars)
            {
                Console.WriteLine("Model: {0}, Year: {1}, Color:{2},Value:{3}", car.Model, car.Year, car.Color, car.Value);
            }

        }

        static void GetCarByColor(Container container, string color)
        {

            // var car = container.Car.Where(x => x.Color == color);
            var car = from carC in container.Car
                      where carC.Color == color
                      select carC;

            if (car == null)
            {
                Console.WriteLine("No car with that color was found");

            }
            else
            {
                foreach (var c in car)
                {
                    Console.WriteLine("Model: {0}, Year: {1}, Color:{2},Value:{3}", c.Model, c.Year, c.Color, c.Value);

                }
            }
        }

        static void AddNewCar(Container container, Car car)
        {

            container.AddToCar(car);

            var res = container.SaveChanges();

            foreach (var response in res)
            {
                Console.WriteLine("Response: {0}", response.StatusCode);
            }

        }

        static void UpdateExistingCar(Container container, Car car, int key)
        {

            var carToUpdate = from carObj in container.Car
                              where carObj.Id == key
                              select carObj;
            if (carToUpdate != null)
            {
                foreach (var c in carToUpdate)
                {
                    container.UpdateObject(c);
                }

                var res = container.SaveChanges();

                foreach (var response in res)
                {
                    Console.WriteLine("Response: {0}", response.StatusCode);
                }
            }
            else
            {
                Console.WriteLine("Car with that key does not exist");
            }

        }

        static void DeleteExistingCar(Container container, int key)
        {
            var car = from p in container.Car
                      where p.Id == key
                      select p;
            if (car != null)
            {

                foreach (var c in car)
                {
                    container.DeleteObject(c);
                }

                var res = container.SaveChanges();

                foreach (var response in res)
                {
                    Console.WriteLine("Response: {0}", response.StatusCode);
                }

            }
            else
            {

                Console.WriteLine("Car with that Key does not exist");


            }


        }
        static void Main(string[] args)
        {
            Container container = new Container(
                    new Uri("https://localhost:44302/"));


            Console.WriteLine(" $$$$$$$$$$$$$$$$$ Display all the cars $$$$$$$$$$$$");

            GetAllCars(container);

            Console.WriteLine("$$$$$$$$$$$$$$$$$$ Display car by color $$$$$$$$$$$$");

            Console.WriteLine("Enter a Color");

            var color = Console.ReadLine();

            GetCarByColor(container, color);

            Console.WriteLine("Add a New Car");

            var car = new Car()
            {
                // Id = 3,
                Model = "Mazda",
                Year = 2020,
                Color = "Pink",
                Value = 20000

            };

            AddNewCar(container, car);


            Console.WriteLine("Update an existing car");

            var carObj = new Car()
            {
                Model = "Bennn",
                Color = "Purple",
                Year = 2019,
                Value = 29000


            };
            UpdateExistingCar(container, carObj, 2);

            Console.WriteLine("Delete Existing Object");

            DeleteExistingCar(container, 1);

            Console.ReadLine();
        }

        static void BatchOperations(Container container, Car car, string color, int key) {

            //Get Cars
            GetAllCars(container);

            //Get Car By Color

            GetCarByColor(container, color);

            //Add new car
            AddNewCar(container, car);

            //Update an existing car 
            UpdateExistingCar(container, car,key);

            //Delete Existing Car
            DeleteExistingCar(container, key);

           // var batchResponse = container.ExecuteBatch(cars,AddNewCar(container,car));

        }
    }

      
}
