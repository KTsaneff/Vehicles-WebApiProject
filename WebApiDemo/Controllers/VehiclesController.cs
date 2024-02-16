using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        [HttpGet]
        public string GetVehicles()
        {
            return $"Reading all the vehicles.";
        }

        [HttpGet("{id}")]
        public string GetVehicleById(int id)
        {
            return $"Reading information for vehicle with ID: {id}";
        }

        [HttpPost]
        public string CreateVehicle()
        {
            return $"Creating a new vehicle";
        }

        [HttpPut("{id}")]
        public string UpdateVehicle(int  id)
        {
            return $"Updating vehicle with ID: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteVehicle(int id)
        {
            return $"Deleting vehicle with ID: {id}";
        }
    }
}
