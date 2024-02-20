using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ActionFilters
{
    public class Vehicle_ValidateUpdateVehicleFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var vehicle = context.ActionArguments["vehicle"] as Vehicle;

            if (id.HasValue && vehicle != null && id != vehicle.Id)
            {
                context.ModelState.AddModelError("VehicleId", "VehicleId is not the same as id.");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
