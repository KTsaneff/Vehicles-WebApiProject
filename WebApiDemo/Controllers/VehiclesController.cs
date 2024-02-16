using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

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
        //public string GetVehicleById(int id, [FromQuery]string brand)
        //public string GetVehicleById(int id, [FromHeader(Name = "Brand")]string brand)
        {
            return $"Reading information for vehicle( ID-{id})";
        }

        [HttpPost]
        public string CreateVehicle([FromForm]Vehicle vehicle)
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
