using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        TantaMVCContext db = new TantaMVCContext();
        public IActionResult Index()
        {
            var result = db.Students.ToList();

            return View("Index", result);
        }
        public IActionResult getAll()
        {
            var result = db.Students.ToList();
            return View("getAll", result);
        }

        public IActionResult getone(int ssn)
        {
            var result = db.Students.Where(s => s.SSN == ssn).ToList();
            return View("getAll", result);
        }
    }
}
