using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult TestAutobyUserProp()
        {
            if (User.Identity.IsAuthenticated)
            {
                Claim c = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
                string str = User.Identity.Name;

                Claim add = User.Claims.FirstOrDefault(u => u.Type == "Address");


                return Content($"{str} User is authenticated ,{c.Value} , {add.Value}");
            }

            return Content("Hello You Must To Login First");
        }
    }
}
