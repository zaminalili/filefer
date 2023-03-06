using filefer.Entity.Models;

namespace filefer.Service.Services
{
    public interface IFileService
    {
        Task UploadFileAsync(UploadedFileViewModel model);
    }
}
