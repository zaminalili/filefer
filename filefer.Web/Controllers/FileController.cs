using filefer.Entity.Entites;
using filefer.Entity.Models;
using filefer.Service.FluentValidation;
using filefer.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace filefer.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService fileService;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadedFileViewModel model)
        {
            var validator = new FileValidator();
            var result = await validator.ValidateAsync(model);

            if (result.IsValid)
                await fileService.UploadFileAsync(model);
            

            return RedirectToAction("Index", "User");
        }
    }
}
