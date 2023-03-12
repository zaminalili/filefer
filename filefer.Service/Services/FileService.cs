using filefer.Entity.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using filefer.Entity.Entites;
using filefer.Data.UnitOfWorks.Abstract;
using filefer.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using filefer.Data.Context;
using filefer.Data.Repositories.Abstract;

namespace filefer.Service.Services
{
    public class FileService: IFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileHelper fileHelper;
        private readonly IFileRepository fileRepository;

        

        public FileService(IUnitOfWork unitOfWork, IFileHelper fileHelper, IFileRepository fileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.fileHelper = fileHelper;
            this.fileRepository = fileRepository;
        }


        public async Task<List<UploadedFile>> GetUserAllFilesAsync(Guid userId)
        {
            return await fileRepository.GetAllFileByUserIdAsync(userId);
        }

        public async Task UploadFileAsync(UploadedFileViewModel model)
        {

            AddFileViewModel addedFile = await fileHelper.Upload(model.File);

            UploadedFile file = new UploadedFile
            {
                FileName = addedFile.FullName,
                FileType = model.File.ContentType,
                UserId = model.UserId,
                FileSize = addedFile.FileSize
            };

            await unitOfWork.GetRepository<UploadedFile>().AddAsync(file);
            await unitOfWork.SaveAsync();
        }

    }
}
