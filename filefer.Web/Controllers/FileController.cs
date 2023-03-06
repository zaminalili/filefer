using filefer.Entity.Entites;
using filefer.Entity.Models;
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
            await fileService.UploadFileAsync(model);

            return RedirectToAction("Index", "User");
        }
    }
}
