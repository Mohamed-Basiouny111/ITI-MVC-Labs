using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class DeptController : Controller
    {
        TantaMVCContext db = new TantaMVCContext();

        //public IActionResult getAll()
        //{
        //    var dept = db.Departments.Include(s => s.Students).Include(i => i.Instructors);
        //    DeptWithStudWithInstVM deptVM = new DeptWithStudWithInstVM();
        //    deptVM.department = dept.ToList();
        //    deptVM.StdCount = dept.Select(s => s.Students).Count();
        //    deptVM.InsCount = dept.Select(i => i.Instructors).Count();
        //    return View("getAll", deptVM);
        //}
        public IActionResult getAll()
        {
            var result = db.Departments.ToList();
            return View("getAll", result);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddNew(Department s)
        {
            if (s.Name != null)
            {
                db.Departments.Add(s);
                db.SaveChanges();

                return RedirectToAction(nameof(getAll));
            }
            return View("Add", s);
        }

        public IActionResult AddV2()
        {
            return View();
        }

        [HttpPost]
        [CheckLocationFilter]
        [AddFooterFilter]
        public IActionResult AddNewV2(Department department)
        {
            if (department.Name != null)
            {
                db.Departments.Add(department);
                db.SaveChanges();

                return RedirectToAction(nameof(getAll));
            }
            return View("Add", department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = db.Departments.FirstOrDefault(s => s.Id == id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department.Name != "")
            {
                db.Departments.Update(department);
                db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }

            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var student = db.Departments.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            db.Departments.Remove(student);
            db.SaveChanges();
            return RedirectToAction(nameof(getAll));
        }
    }
}
