using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Sequoia",
                VehicleType = "SUV",
                Engine = Engine.Petrol,
                ProductionDate = new MonthYear { Month = 5, Year = 2023 }
            },
            new Vehicle
            {
                Id = 2,
                Brand = "Ford",
                Model = "Explorer",
                VehicleType = "SUV",
                Engine = Engine.Diesel,
                ProductionDate = new MonthYear { Month = 6, Year = 2023 }
            },
            new Vehicle
            {
                Id = 3,
                Brand = "Honda",
                Model = "Civic",
                VehicleType = "Car",
                Engine = Engine.Petrol,
                ProductionDate = new MonthYear { Month = 7, Year = 2023 }
            },
            new Vehicle
            {
                Id = 4,
                Brand = "Tesla",
                Model = "Model 3",
                VehicleType = "Car",
                Engine = Engine.Electric,
                ProductionDate = new MonthYear { Month = 8, Year = 2023 }
            },
            new Vehicle
            {
                Id = 5,
                Brand = "Chevrolet",
                Model = "Impala",
                VehicleType = "Car",
                Engine = Engine.Hybrid,
                ProductionDate = new MonthYear { Month = 9, Year = 2023 }
            }
        };

        [HttpGet]
        public string GetVehicles()
        {
            return $"Reading all the vehicles.";
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPost]
        public string CreateVehicle([FromBody] Vehicle vehicle)
        {
            return $"Creating a new vehicle";
        }

        [HttpPut("{id}")]
        public string UpdateVehicle(int id)
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
