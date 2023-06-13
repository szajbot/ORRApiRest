namespace ORRApiRest.Repositorium
{
    public static class CarRepositorium
    {
        private static List<Car> carList = new List<Car>();
        private static int nextCarId = 0;

        public static List<Car> GetAll()
        {
            return carList;
        }

        public static Car? FindCarById(int id)
        {
            return carList.Find(car => car.Id == id);
        }

        public static Car CreateCarFromDTO(CarDTO car)
        {
            nextCarId++;
            var newCar = new Car()
            {
                MakeYear = car.MakeYear,
                Model = car.Model,
                Mileage = car.Mileage,
                SalonId = car.SalonId,
                Id = nextCarId
            };
            carList.Add(newCar);
            return newCar;
        }

        public static Car UpdateCar(Car carToUpdate, CarDTO car)
        {
            carToUpdate.Mileage = car.Mileage;
            carToUpdate.Model = car.Model;
            carToUpdate.MakeYear = car.MakeYear;
            carToUpdate.SalonId = car.SalonId;
            return carToUpdate;
        }

        public static Car UpdateCarMileage(Car carToUpdate, float mileage)
        {
            carToUpdate.Mileage = mileage;
            return carToUpdate;
        }

        public static Car DeleteById(int id)
        {
            Car carToDelete = FindCarById(id);
            if (carToDelete != null)
            {
                carList.Remove(carToDelete);
                return carToDelete;
            } else 
            {
                return null;
            }
        }

        public static List<Car> DeleteAll()
        {
            List<Car> removedCars = new List<Car>();
            removedCars.AddRange(carList);
            carList.Clear();
            return removedCars;
        }
    }
}
