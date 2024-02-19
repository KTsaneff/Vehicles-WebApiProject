namespace WebApiDemo.Models.Repositories
{
    public static class VehicleRepository
    {
        private static List<Vehicle> vehicles = new List<Vehicle>()
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

        public static List<Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public static bool VehicleExists(int id)
        {
            return vehicles.Any(vehicle => vehicle.Id == id);
        }

        public static Vehicle? GetVehicleById(int id)
        {
            return vehicles.FirstOrDefault(v => v.Id == id);
        }

        public static Vehicle? GetVehicleByProperties(string? brand, string? model, string? engine, int? month, int? year)
        {
            MonthYear monthYear = new MonthYear();
            if (month != null && year != null)
            {
                int tempMonth = month.Value;
                int tempYear = year.Value;

                monthYear.Month = tempMonth;
                monthYear.Year = tempYear;
            }
            else
            {
                return null;
            }

            return vehicles.FirstOrDefault(v =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(v.Brand) &&
            v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(model) &&
            !string.IsNullOrWhiteSpace(v.Model) &&
            v.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(engine) &&
            !string.IsNullOrWhiteSpace(v.Engine.ToString()) &&
            v.Engine.ToString().Equals(engine, StringComparison.OrdinalIgnoreCase) &&
            v.ProductionDate.Month == monthYear.Month &&
            v.ProductionDate.Year == monthYear.Year);
        }

        public static void AddVehicle(Vehicle vehicle)
        {
            int maxId = vehicles.Max(vehicle => vehicle.Id);
            vehicle.Id = maxId + 1;

            vehicles.Add(vehicle);
        }

        public static void UpdateVehicle(Vehicle vehicle)
        {
            var vehicleToUpdate = vehicles.First(v => v.Id == vehicle.Id);

            vehicleToUpdate.Brand = vehicle.Brand;
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.VehicleType = vehicle.VehicleType;
            vehicleToUpdate.Engine = vehicle.Engine;
            vehicleToUpdate.ProductionDate = vehicle.ProductionDate;

        }
    }
}
