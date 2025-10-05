using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.Filters
{
    public class CheckLocationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("department", out var depObj))
            {
                var department = depObj as Department;

                if (department != null)
                {
                    var validLocations = new[] { "EG", "USA" };

                    if (!validLocations.Contains(department.Location))
                    {
                        context.Result = new BadRequestObjectResult("Location must be either 'EG' or 'USA'");
                        return;
                    }
                }
            }

            base.OnActionExecuting(context);

        }
    }

}
