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

        public static Car FindCarById(int id)
        {
            return carList.Find(car => car.Id == id);
        }

        public static Car CreateCarFromDTO(CarDTO car)
        {
            nextCarId++;
            Car newCar = new Car();
            newCar.MakeYear = car.MakeYear;
            newCar.Model = car.Model;
            newCar.Mileage = car.Mileage;
            newCar.SalonId = car.SalonId;
            newCar.Id = nextCarId;
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
