using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ActionFilters
{
    public class Vehicle_ValidateVehicleIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _dbContext;
        public Vehicle_ValidateVehicleIdFilterAttribute(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var vehicleId = context.ActionArguments["id"] as int?;

            if (vehicleId.HasValue)
            {
                if (vehicleId.Value <= 0)
                {
                    context.ModelState.AddModelError("VehicleId", "VehicleId is invalid.");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var vehicle = _dbContext.Vehicles.Find(vehicleId.Value);
                    if(vehicle == null)
                    {
                        context.ModelState.AddModelError("VehicleId", "Vehicle doesn't exist.");

                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["vehicle"] = vehicle;
                    }
                }
            }
        }
    }
}
