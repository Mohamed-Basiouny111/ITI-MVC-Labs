using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class AddFooterFilter : ResultFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Controller is Controller controller)
            {
                Console.WriteLine($"Department added successfully at {DateTime.Now}");
            }

            base.OnResultExecuted(context);
        }
    }

}
