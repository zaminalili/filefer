using filefer.Entity.Entites;
using filefer.Service.AutoKey;
using filefer.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace filefer.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAutoKey key;
        private readonly IFileService fileService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAutoKey key, IFileService fileService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.key = key;
            this.fileService = fileService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            
            ViewBag.Id = user.Id;
            ViewBag.Key = user.UserName;

            var files = await fileService.GetUserAllFilesAsync(user.Id);
           
            ViewBag.Files = files;
            
            return View();
        }

        public async Task<IActionResult> CreateUser()
        {

            string Key = key.CreateKey(2, 3);
            string Password = Key + "Def@ult";

            var user = new AppUser
            {
                UserName = Key
            };
                
            var result = await userManager.CreateAsync(user, Password);
            
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "User");
            }

            return View();
        }
    }
}
