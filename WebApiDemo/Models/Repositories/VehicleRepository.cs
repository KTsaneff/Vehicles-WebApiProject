namespace WebApiDemo.Models.Repositories
{
    public static class VehicleRepository
    {
        private static List<Vehicle> vehicles = new List<Vehicle>()
        {
            
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
            if (month == null || year == null)
            {
                return null;
            }

            DateTime productioDate = new DateTime(year.Value, month.Value, 1);

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
            DateTime.Compare(v.ProductionDate, productioDate) == 0);
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

        public static void DeleteVehicle(int vehicleId)
        {
            var vehicle = GetVehicleById(vehicleId);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
            }
        }
    }
}
