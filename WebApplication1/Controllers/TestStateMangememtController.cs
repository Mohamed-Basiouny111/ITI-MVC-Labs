using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestStateMangememtController : Controller
    {
        public IActionResult GetSession()
        {
            int? id = HttpContext.Session.GetInt32("StudentId");
            string name = HttpContext.Session.GetString("LastStudentName");
            return Content($"Last Student Added Is {name} =>  {id}");
        }

        public IActionResult GetCookie()
        {
            string? Name = HttpContext.Request.Cookies["LastDepartment"];
            return Content($"Last Department {Name}");
        }

     
    }
}
