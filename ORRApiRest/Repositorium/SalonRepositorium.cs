using System.Diagnostics;

namespace ORRApiRest.Repositorium
{
    public static class SalonRepositorium
    {
        private static List<Salon> salonList = new List<Salon>();
        private static int nextSalonId = 0;

        public static List<Salon> GetAll()
        {
            List<Car> cars = CarRepositorium.GetAll();

            List<Salon> salonWithCarsList = new List<Salon>();

            foreach (Salon salon in salonList)
            {
                List<Car> salonCars = cars.Where(car => car.SalonId == salon.Id).ToList();
                Salon salonWithCars = new Salon
                {
                    Id = salon.Id,
                    Name = salon.Name,
                    CarList = salonCars,

                };
                salonWithCarsList.Add(salonWithCars);
            }

            return salonWithCarsList;
        }

        public static Salon FindSalonWithCarsById(int id)
        {
            List<Car> cars = CarRepositorium.GetAll();

            Salon salon = salonList.Find(salon => salon.Id == id);
            List<Car> salonCars = cars.Where(car => car.SalonId == salon.Id).ToList();

            Salon salonWithCars = new Salon
            {
                Id = id,
                Name = salon.Name,
                CarList = salonCars,

            };
            return salonWithCars;
        }

        public static Salon FindSalonById(int id)
        {
            return salonList.Find(salon => salon.Id == id);
        }

        public static Salon CreateSalon(Salon salon)
        {
            nextSalonId++;
            var newSalon = new Salon()
            {
                Id = nextSalonId,
                Name = salon.Name,
                CarList = new List<Car>()
            };
            
            salonList.Add(newSalon);
            return newSalon;
        }

        public static Salon UpdateSalon(Salon salonToUpdate, Salon salon)
        {
            salonToUpdate.Name = salon.Name;
            return salonToUpdate;
        }

        public static Salon UpdateSalonName(Salon salonToUpdate, string name)
        {
            salonToUpdate.Name = name;
            return salonToUpdate;
        }

        public static Salon DeleteById(int id)
        {
            Salon salonToDelete = FindSalonById(id);
            if (salonToDelete == null)
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
            salonList.Remove(salonToDelete);
            return salonToDelete;
        }

        public static List<Salon> DeleteAll()
        {
            List<Salon> removedSalons = new List<Salon>();
            removedSalons.AddRange(salonList);
            salonList.Clear();
            return removedSalons;
        }

    }
}
