using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class DeptController : Controller
    {
        TantaMVCContext db = new TantaMVCContext();

        public IActionResult getAll()
        {
            var dept = db.Departments.Include(s => s.Students).Include(i => i.Instructors);
            DeptWithStudWithInstVM deptVM = new DeptWithStudWithInstVM();
            deptVM.department = dept.ToList();
            deptVM.StdCount = dept.Select(s => s.Students).Count();
            deptVM.InsCount = dept.Select(i => i.Instructors).Count();
            return View("getAll", deptVM);
        }
    }
}
