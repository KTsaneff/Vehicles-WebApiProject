using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models.Validations
{
    public class Vehicle_EnsureCorrectBrandStringLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var vehicle = validationContext.ObjectInstance as Vehicle;

            if (vehicle != null)
            {
                if (vehicle?.Brand?.Length < 2)
                {
                    return new ValidationResult("Vehicle Brand cannot be less than 2 symbols.");
                }
                else if (vehicle?.Brand?.Length > 50)
                {
                    return new ValidationResult("Vehicle Brand max length is 50 symbols.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
