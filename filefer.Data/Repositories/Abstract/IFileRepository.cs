using filefer.Entity.Entites;

namespace filefer.Data.Repositories.Abstract
{
    public interface IFileRepository
    {
        Task<List<UploadedFile>> GetAllFileByUserIdAsync(Guid userId);
    }
}
