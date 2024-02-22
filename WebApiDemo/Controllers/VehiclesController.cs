using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
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
        private readonly ApplicationDbContext _dbContext;

        public VehiclesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(_dbContext.Vehicles.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Vehicle_ValidateVehicleIdFilterAttribute))]
        public IActionResult GetVehicleById(int id)
        {
            return Ok(HttpContext.Items["vehicle"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Vehicle_ValidateCreateVehicleFilterAttribute))]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            this._dbContext.Vehicles.Add(vehicle);
            this._dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Vehicle_ValidateVehicleIdFilterAttribute))]
        [Vehicle_ValidateUpdateVehicleFilter]
        [TypeFilter(typeof(Vehicle_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleToUpdate = HttpContext.Items["vehicle"] as Vehicle;

            vehicleToUpdate.Brand = vehicle.Brand;
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.VehicleType = vehicle.VehicleType;
            vehicleToUpdate.Engine = vehicle.Engine;
            vehicleToUpdate.ProductionDate = vehicle.ProductionDate;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Vehicle_ValidateVehicleIdFilterAttribute))]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicleToDelete = HttpContext.Items["vehicle"] as Vehicle;

            _dbContext.Vehicles.Remove(vehicleToDelete);
            _dbContext.SaveChanges();

            return Ok(vehicleToDelete);
        }
    }
}
