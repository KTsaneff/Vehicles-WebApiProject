using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ActionFilters
{
    public class Vehicle_ValidateCreateVehicleFilterAttribute : ActionFilterAttribute
    {
        private ApplicationDbContext _dbcContext;
        public Vehicle_ValidateCreateVehicleFilterAttribute(ApplicationDbContext dbContext)
        {
            _dbcContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var vehicle = context.ActionArguments["vehicle"] as Vehicle;

            if (vehicle == null)
            {
                context.ModelState.AddModelError("Vehicle", "Vehicle object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingVehicle = _dbcContext.Vehicles.FirstOrDefault(v =>
                    !string.IsNullOrWhiteSpace(vehicle.Brand) &&
                    !string.IsNullOrWhiteSpace(v.Brand) &&
                    v.Brand.ToLower() == vehicle.Brand.ToLower() &&
                    !string.IsNullOrWhiteSpace(vehicle.Model) &&
                    !string.IsNullOrWhiteSpace(v.Model) &&
                    v.Model.ToLower() == vehicle.Model.ToLower() &&
                    v.Engine == vehicle.Engine &&
                    v.ProductionDate.Year == vehicle.ProductionDate.Year);

                if (existingVehicle != null)
                {
                    context.ModelState.AddModelError("Vehicle", "Vehicle already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                };
            }
        }
    }
}
