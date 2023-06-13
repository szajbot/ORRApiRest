using System.Diagnostics;

namespace ORRApiRest.Repositorium
{
    public static class SalonRepositorium
    {
        private static List<Salon> salonList = new List<Salon>();
        private static int nextSalonId = 0;

        public static List<SalonWithCars> GetAll()
        {
            List<Car> cars = CarRepositorium.GetAll();

            List<SalonWithCars> salonWithCarsList = new List<SalonWithCars>();

            foreach (Salon salon in salonList)
            {
                List<Car> salonCars = cars.Where(car => car.SalonId == salon.Id).ToList();
                SalonWithCars salonWithCars = new SalonWithCars(salon.Id, salon.Name, salonCars); // Assuming SalonWithCars is a custom class to hold salon and car list
                salonWithCarsList.Add(salonWithCars);
            }

            return salonWithCarsList;
        }

        public static SalonWithCars FindSalonWithCarsById(int id)
        {
            List<Car> cars = CarRepositorium.GetAll();

            Salon salon = salonList.Find(salon => salon.Id == id);
            List<Car> salonCars = cars.Where(car => car.SalonId == salon.Id).ToList();

            SalonWithCars salonWithCars = new SalonWithCars(id, salon.Name, salonCars);
            return salonWithCars;
        }

        public static Salon FindSalonById(int id)
        {
            return salonList.Find(salon => salon.Id == id);
        }

        public static Salon CreateSalonFromDTO(SalonDTO salonDTO)
        {
            nextSalonId++;
            Salon newSalon = new Salon();
            newSalon.Name = salonDTO.Name;
            newSalon.Id = nextSalonId;
            salonList.Add(newSalon);
            return newSalon;
        }

        public static SalonWithCars UpdateSalon(SalonWithCars salonToUpdate, SalonDTO salon)
        {
            salonToUpdate.Name = salon.Name;
            return salonToUpdate;
        }

        public static SalonWithCars UpdateSalonName(SalonWithCars salonToUpdate, string name)
        {
            salonToUpdate.Name = name;
            return salonToUpdate;
        }

        public static Salon DeleteById(int id)
        {
            Salon salonToDelete = FindSalonById(id);
            if (salonToDelete != null)
            {
                salonList.Remove(salonToDelete);
                return salonToDelete;
            }
            else
            {
                return null;
            }
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
