using ORRApiRest.Repositorium;
using System.ServiceProcess;

namespace ORRApiRest.Services
{
    public class salonService : ServiceBase
    {
        public List<Salon> GetAllSalons()
        {
            return SalonRepositorium.GetAll();
        }

        public Salon GetSalonById(int id)
        {
            Salon salonToFind = SalonRepositorium.FindSalonWithCarsById(id);
            if (salonToFind != null)
            {
                return salonToFind;
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }

        public Salon CreateSalon(Salon salon)
        {
            return SalonRepositorium.CreateSalon(salon);
        }

        public Salon UpdateSalonById(int id, Salon salon)
        {
            Salon salonToUpdate = SalonRepositorium.FindSalonWithCarsById(id);
            if (salonToUpdate != null)
            {
                return SalonRepositorium.UpdateSalon(salonToUpdate, salon);
            }
            else
            {
                throw new Exception($"Salon with ID {id} does not exist.");
            }
        }
        public Salon PatchSalonName(int id, string name)
        {
            Salon salonToUpdate = SalonRepositorium.FindSalonWithCarsById(id);
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
