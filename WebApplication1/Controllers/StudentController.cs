using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

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

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddNew(Student s)
        {
            if (s.Name != null)
            {
                db.Students.Add(s);
                db.SaveChanges();
              
                return RedirectToAction(nameof(getAll));
            }
            return View("Add", s);
        }
    }
}
