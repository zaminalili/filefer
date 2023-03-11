using filefer.Entity.Entites;
using filefer.Entity.Models;
using filefer.Service.FluentValidation;
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
            var validator = new LoginValidator();
            var result = await validator.ValidateAsync(model);

            if (result.IsValid)
            {
                string UserName = model.UserName.ToUpper();
                string Password = UserName + "Def@ult";
                
                var user = await userManager.FindByNameAsync(UserName);

                if (user != null)
                {
                    var signinResult = await signInManager.PasswordSignInAsync(user, Password, false, false);

                    if (signinResult.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Key input failed");

                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Key input failed");

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
