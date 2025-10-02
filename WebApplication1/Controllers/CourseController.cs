using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        TantaMVCContext db = new TantaMVCContext();

        public IActionResult Index()
        {
            var result = db.Courses.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (course.MinDegree >= course.Degree)
            {
                ModelState.AddModelError("MinDegree", "MinDegree must be less than Degree");
            }

            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("Add", course);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = db.Courses.FirstOrDefault(s => s.Num == id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (course.MinDegree >= course.Degree)
            {
                ModelState.AddModelError("MinDegree", "MinDegree must be less than Degree");
            }
            
                if (ModelState.IsValid)
                {
                    db.Courses.Update(course);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = db.Courses.FirstOrDefault(s => s.Num == id);
            if (course == null)
                return NotFound();
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
