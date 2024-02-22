using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Engine)
                .HasConversion<string>();

            //Data_Seeding

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    Brand = "Toyota",
                    Model = "Sequoia",
                    VehicleType = "SUV",
                    Engine = Engine.Petrol,
                    ProductionDate = new DateTime(2023, 5, 1)
                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Ford",
                    Model = "Explorer",
                    VehicleType = "SUV",
                    Engine = Engine.Diesel,
                    ProductionDate = new DateTime(2023, 6, 1)
                },
                new Vehicle
                {
                    Id = 3,
                    Brand = "Honda",
                    Model = "Civic",
                    VehicleType = "Car",
                    Engine = Engine.Petrol,
                    ProductionDate = new DateTime(2023, 7, 1)
                },
                new Vehicle
                {
                    Id = 4,
                    Brand = "Tesla",
                    Model = "Model 3",
                    VehicleType = "Car",
                    Engine = Engine.Electric,
                    ProductionDate = new DateTime(2023, 8, 1)
                },
                new Vehicle
                {
                    Id = 5,
                    Brand = "Chevrolet",
                    Model = "Impala",
                    VehicleType = "Car",
                    Engine = Engine.Hybrid,
                    ProductionDate = new DateTime(2023, 9, 1)
                });
        }
    }
}
