using System.ComponentModel.DataAnnotations;
using WebApiDemo.Models.Validations;

namespace WebApiDemo.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Vehicle_EnsureCorrectBrandStringLength]
        public string? Brand { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        public string? VehicleType { get; set; }

        [EnumDataType(typeof(Engine))]
        [Required]
        public Engine Engine { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

    }
}
