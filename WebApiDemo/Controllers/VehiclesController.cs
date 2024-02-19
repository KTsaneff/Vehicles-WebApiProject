using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(VehicleRepository.GetVehicles());
        }

        [HttpGet("{id}")]
        [Vehicle_ValidateVehicleIdFilter]
        public IActionResult GetVehicleById(int id)
        {
           return Ok(VehicleRepository.GetVehicleById(id));
        }

        [HttpPost]
        [Vehicle_ValidateCreateVehicleFilter]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {           
            VehicleRepository.AddVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id)
        {
            return Ok($"Updating vehicle with ID: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            return Ok($"Deleting vehicle with ID: {id}");
        }
    }
}
