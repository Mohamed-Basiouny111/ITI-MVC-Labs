using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class HandelExceptionFiterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            Console.WriteLine($"Error: {exception.Message}");

 
            context.Result = new ObjectResult(new
            {
                Message = "Error.",
                Error = exception.Message,
                Time = DateTime.Now
            })
            {
                StatusCode = 500 
            };
            context.ExceptionHandled = true;
        }
    }

}
