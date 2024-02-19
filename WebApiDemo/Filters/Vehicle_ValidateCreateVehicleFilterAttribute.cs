using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters
{
    public class Vehicle_ValidateCreateVehicleFilterAttribute : ActionFilterAttribute
    {
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
                var existingVehicle = VehicleRepository
                .GetVehicleByProperties(vehicle.Brand, vehicle.Model, vehicle.Engine.ToString(), vehicle.ProductionDate.Month, vehicle.ProductionDate.Year);

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
