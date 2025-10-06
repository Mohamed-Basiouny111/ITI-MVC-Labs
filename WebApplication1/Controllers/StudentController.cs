using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Filters;
using WebApplication1.Middlewares;
using WebApplication1.Models;
using WebApplication1.Repositry;
using WebApplication1.IRepo;

namespace WebApplication1.Controllers
{
   
    public class StudentController : Controller
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        //TantaMVCContext db = new TantaMVCContext();

        //StudentRepo _studentRepo;
        //IStudentRepo _studentRepo;
        //public StudentController(IStudentRepo studentRepo)//Inject => Add
        //{
        //    //_studentRepo = new StudentRepo();
        //    _studentRepo = studentRepo;
        //}

        private readonly GenericStudentRepo _studentRepo;
        private readonly GenericDepartment _deptRepo;
        public StudentController(GenericStudentRepo studentRepo, GenericDepartment deptRepo)
        {
            _studentRepo = studentRepo;
            _deptRepo = deptRepo;
        }

        //[CheckUserFilter]
        public IActionResult Index()
        {
            var result = _studentRepo.GetStudent();

            return View("Index", result);
        }

        public IActionResult getone(int ssn)
        {
            var result = _studentRepo.GetById(ssn);
            return View("getAll", result);
        }
       
        public IActionResult getAll()
        {
            var result = _studentRepo.GetStudent();
            return View("getAll", result);
        }

      //  [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Add()
        {
            //ViewBag.dept = db.Departments.ToList();
            ViewBag.dept = _deptRepo.GetAll();
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
                //db.Students.Add(s);
                //db.SaveChanges();

                _studentRepo.Add(s);

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
            var result = _studentRepo.GetById(id);
            // ViewBag.dept = db.Departments.ToList();
            ViewBag.dept = _deptRepo.GetAll();
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student.Name != "")
            {
                //db.Students.Update(student);
                //db.SaveChanges();
                _studentRepo.Update(student);
                return RedirectToAction(nameof(getAll));
            }

            // ViewBag.dept = db.Departments.ToList();
            ViewBag.dept = _deptRepo.GetAll();
            return View(student);
        }
       
        public IActionResult Delete(int id)
        {
            //var student = db.Students.FirstOrDefault(s => s.SSN == id);
            //if (student == null)
            //    return NotFound();
            //db.Students.Remove(student);
            //db.SaveChanges();
            _studentRepo.Delete(id);
            return RedirectToAction(nameof(getAll));
        }
    }
}
