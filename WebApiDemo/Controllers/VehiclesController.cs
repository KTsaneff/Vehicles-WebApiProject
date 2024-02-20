using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Filters.ActionFilters;
using WebApiDemo.Filters.ExceptionFilters;
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
        [Vehicle_ValidateVehicleIdFilter]
        [Vehicle_ValidateUpdateVehicleFilter]
        [Vehicle_HandleUpdateExceptionsFilter]
        public IActionResult UpdateVehicle(int id, Vehicle vehicle)
        {
            VehicleRepository.UpdateVehicle(vehicle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Vehicle_ValidateVehicleIdFilter]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = VehicleRepository.GetVehicleById(id);
            VehicleRepository.DeleteVehicle(id);

            return Ok(vehicle);
        }
    }
}
