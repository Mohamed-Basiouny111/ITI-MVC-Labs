using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class CheckUserFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            if (!headers.ContainsKey("Student"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var headerValue = headers["Student"].ToString();

            if (string.IsNullOrEmpty(headerValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }

}
