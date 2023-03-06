using filefer.Entity.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using filefer.Entity.Entites;
using filefer.Data.UnitOfWorks.Abstract;
using filefer.Service.Helpers;

namespace filefer.Service.Services
{
    public class FileService: IFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileHelper fileHelper;

        private readonly string wwwroot;
        private readonly IHostingEnvironment env;
        private const string folderName = "Files";

        public FileService(IHostingEnvironment env, IUnitOfWork unitOfWork, IFileHelper fileHelper)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
            this.unitOfWork = unitOfWork;
            this.fileHelper = fileHelper;
        }


        public async Task UploadFileAsync(UploadedFileViewModel model)
        {

            string FullName = await fileHelper.Upload(model.File);

            UploadedFile file = new UploadedFile
            {
                FileName = FullName,
                FileType = model.File.ContentType,
                UserId = model.UserId,
            };

            await unitOfWork.GetRepository<UploadedFile>().AddAsync(file);
            await unitOfWork.SaveAsync();
        }

    }
}
