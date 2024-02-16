namespace WebApiDemo.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? VehicleType { get; set; }

        public Engine? Engine { get; set; }

        public MonthYear? ProductionDate { get; set; }

    }
}
