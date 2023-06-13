using Microsoft.AspNetCore.Mvc;
using ORRApiRest.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;


namespace ORRApiRest.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarService carService = new CarService();

        [HttpGet]
        public List<Car> ReadAll() => carService.GetAllCars();
        
        [HttpGet]
        [Route("{id}")]
        public Car Read(int id) => carService.GetCarById(id);

        [HttpPost]
        public Car Create([FromBody] CarDTO car) => carService.CreateCarFromDTO(car);

        [HttpPut("{id}")]
        public Car UpdateCar(int id, [FromBody] CarDTO car) => carService.UpdateCarByIdFromDto(id, car);

        [HttpPatch("{id}")]
        public Car UpdateMileage(int id, float mileage) => carService.PatchCarMileage(id, mileage);

        [HttpDelete("{id}")]
        public Car Delete(int id) => carService.DeleteById(id);

        [HttpDelete]
        public List<Car> DeleteAll() => carService.DeleteAll();
    }
}
