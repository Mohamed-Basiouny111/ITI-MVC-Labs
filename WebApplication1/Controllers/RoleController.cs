using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager; 
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM userRole)
        {
            if (ModelState.IsValid)
            {
                // Save to database
                IdentityRole role = new IdentityRole();
                role.Name = userRole.Role;
                IdentityResult res = await _roleManager.CreateAsync(role);
                if (res.Succeeded)
                {
                    return View();
                }
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(userRole);
        }
    }
}
