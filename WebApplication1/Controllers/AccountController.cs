using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //map From vm to model
                ApplicationUser user = new ApplicationUser();
                user.UserName = userVM.UserName;
                user.Address = userVM.Address;
                user.PasswordHash = userVM.Password;

                //Save DataBase
                //IdentityResult res = await userManager.CreateAsync(user);
                IdentityResult res = await userManager.CreateAsync(user, userVM.Password);
                if (res.Succeeded)
                {
                    //Create Cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Register", userVM);
                }

            }
            return View("Register", userVM);
        }

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVm)
        {
            if (ModelState.IsValid)
            {
                //check User
                ApplicationUser user = await userManager.FindByNameAsync(userVm.UserName);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userVm.Password);
                    if (found)
                    {
                        //Create Cookie
                       await signInManager.SignInAsync(user, userVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid UserName Or Password");
            }
            return View("Login", userVm);
        }
    }
}
