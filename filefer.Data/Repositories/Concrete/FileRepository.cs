using filefer.Data.Context;
using filefer.Data.Repositories.Abstract;
using filefer.Entity.Entites;
using Microsoft.EntityFrameworkCore;

namespace filefer.Data.Repositories.Concrete
{
    public class FileRepository: IFileRepository
    {
        private readonly AppDbContext db;

        public FileRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<UploadedFile>> GetAllFileByUserIdAsync(Guid userId)
        {
            var files = await db.Set<UploadedFile>()
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return files;
        }
    }
}
