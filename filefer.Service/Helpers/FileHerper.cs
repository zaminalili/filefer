using filefer.Data.UnitOfWorks.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace filefer.Service.Helpers
{
    public class FileHerper: IFileHelper
    {
        private readonly string wwwroot;
        private readonly IHostingEnvironment env;
        private const string folderName = "Files";

        public FileHerper(IHostingEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }

        public async Task<string> Upload(IFormFile file)
        {
            if (!Directory.Exists($"{wwwroot}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{folderName}");
            };

            string oldFileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            DateTime date = DateTime.Now;

            string newFileName = $"{oldFileName}-{date.Minute}{date.Second}{fileExtension}";

            var path = Path.Combine($"{wwwroot}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(stream);

            await stream.FlushAsync();


            return $"{folderName}/{newFileName}";
        }
    }
}
