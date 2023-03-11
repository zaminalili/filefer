using filefer.Entity.Entites;
using filefer.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace filefer.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.UserName+"Def@ult", false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unsucceeded Key");

                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Unsucceeded Key");

                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
