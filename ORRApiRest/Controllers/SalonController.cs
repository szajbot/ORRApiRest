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
        public List<SalonWithCars> ReadAll() => salonService.GetAllSalons();

        [HttpGet]
        [Route("{id}")]
        public SalonWithCars Read(int id) => salonService.GetSalonById(id);
        
        [HttpPost]
        public Salon Create([FromBody] SalonDTO salonDTO) => salonService.CreateSalonFromDTO(salonDTO);
        
        [HttpPut("{id}")]
        public SalonWithCars UpdateSalon(int id, [FromBody] SalonDTO salonDTO) => salonService.UpdateSalonByIdFromDto(id, salonDTO);

        
        [HttpPatch("{id}")]
        public SalonWithCars UpdateName(int id, string name) => salonService.PatchSalonName(id, name);
        
        
        [HttpDelete("{id}")]
        public Salon Delete(int id) => salonService.DeleteById(id);


        [HttpDelete]
        public List<Salon> DeleteAll() => salonService.DeleteAll();
    }
}
