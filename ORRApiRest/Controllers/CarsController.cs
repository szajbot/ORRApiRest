using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;


namespace ORRApiRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private static List<Car> carList = new List<Car>();
        private static int carCount = 0;

        [HttpGet]
        [Route("cars")]
        public IEnumerable<Car> GetAll() => carList.ToArray();


        [HttpGet("car/{id}")]
        public IEnumerable<Car> Get(int id)
        {

            Car carToFind = carList.Find(car => car.Id == id);
            if (carToFind != null)
            {
                yield return carToFind;
            }
            else
            {
                Console.WriteLine($"Car with ID {id} does not exist.");
            }
        }

        [HttpPost]
        [Route("car")]
        public IEnumerable<Car> Put([FromBody] CarDTO car)
        {
            carCount++;
            Car newCar = new Car();
            newCar.MakeYear = car.MakeYear;
            newCar.Model = car.Model;
            newCar.Mileage = car.Mileage;
            newCar.Id = carCount;
            carList.Add(newCar);
            yield return newCar;
        }

        [HttpPut("car/{id}")]
        public IEnumerable<Car> Update(int id, [FromBody] CarDTO car)
        {
            Car carToFind = carList.Find(car => car.Id == id);
            if (carToFind != null)
            {
                carToFind.MakeYear = car.MakeYear;
                carToFind.Model = car.Model;
                carToFind.Mileage = car.Mileage;
                yield return carToFind;
            }
            else
            {
                Console.WriteLine($"Car with ID {id} does not exist.");
            }
        }

        [HttpPatch("car/{id}")]
        public IEnumerable<Car> PatchMileage(int id, float mileage)
        {
            Car carToFind = carList.Find(car => car.Id == id);
            if (carToFind != null)
            {
                carToFind.Mileage = mileage;
                yield return carToFind;
            }
            else
            {
                Console.WriteLine($"Car with ID {id} does not exist.");
            }
        }

        [HttpDelete("car/{id}")]
        public IEnumerable<Car> DeleteOne(int id)
        {

            Car carToFind = carList.Find(car => car.Id == id);
            if (carToFind != null)
            {
                carList.Remove(carToFind);
                yield return carToFind;
            }
            else
            {
                Console.WriteLine($"Car with ID {id} does not exist.");
            }
        }

        [HttpDelete("cars")]
        public IEnumerable<Car> DeleteAll()
        {
            List<Car> removedCars = new List<Car>();
            removedCars.AddRange(carList);
            carList.Clear();
            return removedCars.ToArray();
        }

    }
}
