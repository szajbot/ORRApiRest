using ORRApiRest.Repositorium;
using System.ServiceProcess;

namespace ORRApiRest.Services
{
    public class salonService : ServiceBase
    {
        public List<SalonWithCars> GetAllSalons()
        {
            return SalonRepositorium.GetAll();
        }

        public SalonWithCars GetSalonById(int id)
        {
            SalonWithCars salonToFind = SalonRepositorium.FindSalonWithCarsById(id);
            if (salonToFind != null)
            {
                return salonToFind;
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }

        public Salon CreateSalonFromDTO(SalonDTO salonDTO)
        {
            return SalonRepositorium.CreateSalonFromDTO(salonDTO);
        }

        public SalonWithCars UpdateSalonByIdFromDto(int id, SalonDTO salonDTO)
        {
            SalonWithCars salonToUpdate = SalonRepositorium.FindSalonWithCarsById(id);
            if (salonToUpdate != null)
            {
                return SalonRepositorium.UpdateSalon(salonToUpdate, salonDTO);
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }
        public SalonWithCars PatchSalonName(int id, string name)
        {
            SalonWithCars salonToUpdate = SalonRepositorium.FindSalonWithCarsById(id);
            if (salonToUpdate != null)
            {
                return SalonRepositorium.UpdateSalonName(salonToUpdate, name);
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }

        public Salon DeleteById(int id)
        {
            Salon salonToDelete = SalonRepositorium.DeleteById(id);
            if (salonToDelete != null)
            {
                return salonToDelete;
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }

        public List<Salon> DeleteAll()
        {
            return SalonRepositorium.DeleteAll();
        }
    }
}
