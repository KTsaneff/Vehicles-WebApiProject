using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ExceptionFilters
{
    public class Vehicle_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var stringVehicleId = context.RouteData.Values["id"] as string;

            if(int.TryParse(stringVehicleId, out int vehicleId))
            {
                if (!VehicleRepository.VehicleExists(vehicleId))
                {
                    context.ModelState.AddModelError("VehicleId", "Vehicle doesn't exist anymore.");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
