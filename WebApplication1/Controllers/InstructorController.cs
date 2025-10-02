using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        TantaMVCContext db = new TantaMVCContext();

        public IActionResult getAll()
        {
            var result = db.Instructors.Include(x=>x.Department).ToList();
            return View("getAll", result);
        }

        public IActionResult Add()
        {
            ViewBag.dept = db.Departments.ToList();
            return View();
        }

        public IActionResult AddNew(Instructor s)
        {
            if (s.Name != null)
            {
                db.Instructors.Add(s);
                db.SaveChanges();

                return RedirectToAction(nameof(getAll));
            }
            return View("Add", s);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = db.Instructors.FirstOrDefault(s => s.SSN == id);
            ViewBag.dept = db.Departments.ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (instructor.Name != "")
            {
                db.Instructors.Update(instructor);
                db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }

            ViewBag.dept = db.Departments.ToList();
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = db.Instructors.FirstOrDefault(s => s.SSN == id);
            if (instructor == null)
                return NotFound();
            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction(nameof(getAll));
        }
    }
}
