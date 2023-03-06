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

        

        public FileService(IUnitOfWork unitOfWork, IFileHelper fileHelper)
        {
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
