using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Filters;
using WebApplication1.Middlewares;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    public class StudentController : Controller
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        TantaMVCContext db = new TantaMVCContext();

        [CheckUserFilter]
        public IActionResult Index()
        {
            var result = db.Students.Include(d => d.Department).Include(c => c.CourseStudents).ThenInclude(cs => cs.Course).ToList();

            return View("Index", result);
        }

        public IActionResult getone(int ssn)
        {
            var result = db.Students.Where(s => s.SSN == ssn).ToList();
            return View("getAll", result);
        }
       
        public IActionResult getAll()
        {
            var result = db.Students.Include(d=>d.Department).ToList();
            return View("getAll", result);
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Add()
        {
            ViewBag.dept = db.Departments.ToList();
            return View();
        }

        public IActionResult AddNew(Student s)
        {
            //try
            //{
            //    int z = 0;
            //    int x = 5 / z;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error happened while loading Index");
            //}

            if (s.Name != null)
            {
                db.Students.Add(s);
                db.SaveChanges();

                //Session
                HttpContext.Session.SetString("LastStudentName", s.Name);
                HttpContext.Session.SetInt32("StudentId", s.SSN);

                //Cookie
                CookieOptions op = new CookieOptions();
                op.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append("LastDepartment", s.DeptId.ToString(), op);

                //TempData
                TempData["SuccessMessage"] = "Student added successfully!";
                return RedirectToAction(nameof(getAll));
            }
            return View("Add", s);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = db.Students.FirstOrDefault(s => s.SSN == id);
            ViewBag.dept = db.Departments.ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student.Name != "")
            {
                db.Students.Update(student);
                db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }

            ViewBag.dept = db.Departments.ToList();
            return View(student);
        }
       
        public IActionResult Delete(int id)
        {
            var student = db.Students.FirstOrDefault(s => s.SSN == id);
            if (student == null)
                return NotFound();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction(nameof(getAll));
        }
    }
}
