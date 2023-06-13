using ORRApiRest.Repositorium;
using System.ServiceProcess;

namespace ORRApiRest.Services
{
    public class CarService : ServiceBase
    {

        public List<Car> GetAllCars()
        {
            return CarRepositorium.GetAll();
        }

        public Car GetCarById(int id)
        {
            Car carToFind = CarRepositorium.FindCarById(id);
            if (carToFind != null)
            {
                return carToFind;
            }
            else
            {
                throw new Exception($"Car with ID {id} does not exist.");
            }
        }

        public Car CreateCarFromDTO(CarDTO car)
        {
            return CarRepositorium.CreateCarFromDTO(car);
        }

        public Car UpdateCarByIdFromDto(int id, CarDTO car)
        {
            Car carToUpdate = CarRepositorium.FindCarById(id); 
            if (carToUpdate != null)
            {
                return CarRepositorium.UpdateCar(carToUpdate, car);
            }
            else
            {
                throw new Exception($"Car with ID {id} does not exist.");
            }
        }

        public Car PatchCarMileage(int id, float mileage)
        {
            Car carToUpdate = CarRepositorium.FindCarById(id);
            if (carToUpdate != null)
            {
                return CarRepositorium.UpdateCarMileage(carToUpdate, mileage);
            }
            else
            {
                throw new Exception($"Car with ID {id} does not exist.");
            }
        }

        public Car DeleteById(int id)
        {
            Car carToDelete = CarRepositorium.DeleteById(id);
            if (carToDelete != null) 
            {
                return carToDelete;
            } else
            {
                throw new Exception($"Car with ID {id} does not exist.");
            }
        }

        internal List<Car> DeleteAll()
        {
            return CarRepositorium.DeleteAll();        
        }
    }
}
