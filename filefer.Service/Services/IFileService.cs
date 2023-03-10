using filefer.Entity.Entites;
using filefer.Entity.Models;

namespace filefer.Service.Services
{
    public interface IFileService
    {
        Task UploadFileAsync(UploadedFileViewModel model);
        Task<List<UploadedFile>> GetUserAllFilesAsync(Guid userId);
    }
}
