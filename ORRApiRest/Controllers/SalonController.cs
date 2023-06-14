using Microsoft.AspNetCore.Mvc;
using ORRApiRest.Services;

namespace ORRApiRest.Controllers
{
    [Route("api/salon")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private salonService salonService = new salonService();

        [HttpGet]
        public List<Salon> ReadAll() => salonService.GetAllSalons();

        [HttpGet]
        [Route("{id}")]
        public Salon Read(int id) => salonService.GetSalonById(id);
        
        [HttpPost]
        public Salon Create([FromBody] Salon salon) => salonService.CreateSalon(salon);
        
        [HttpPut("{id}")]
        public Salon UpdateSalon(int id, [FromBody] Salon salon) => salonService.UpdateSalonById(id, salon);

        
        [HttpPatch("{id}")]
        public Salon UpdateName(int id, string name) => salonService.PatchSalonName(id, name);
        
        
        [HttpDelete("{id}")]
        public Salon Delete(int id) => salonService.DeleteById(id);


        [HttpDelete]
        public List<Salon> DeleteAll() => salonService.DeleteAll();
    }
}
