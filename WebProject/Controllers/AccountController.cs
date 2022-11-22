using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("AddAnimal","Administrator");
                }


            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username,string password)
        {
            IdentityUser user = new IdentityUser { UserName = username};
            var res = await _userManager.CreateAsync(user,password);
            if (res.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

    }
}
