using filefer.Data.Context;
using filefer.Data.Repositories.Abstract;
using filefer.Data.Repositories.Concrete;
using filefer.Data.UnitOfWorks.Abstract;
using Microsoft.EntityFrameworkCore;

namespace filefer.Data.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        public UnitOfWork(AppDbContext db)
        {
            this.db = db;
        }

        public ValueTask DisposeAsync()
        {
            return db.DisposeAsync();
        }

        Repository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(db);
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
