using filefer.Data.Repositories.Concrete;

namespace filefer.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        Repository<T> GetRepository<T>() where T : class, new();
        Task<int> SaveAsync();
        int Save();
    }
}
