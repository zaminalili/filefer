using System.Linq.Expressions;

namespace filefer.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
