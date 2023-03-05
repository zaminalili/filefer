using filefer.Data.Context;
using filefer.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace filefer.Data.Repositories.Concrete
{
    public class Repository<T>: IRepository<T> where T : class, new()
    {
        private readonly AppDbContext db;
        public Repository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => db.Set<T>().Remove(entity));
        }

        public async Task<T> GetById(Guid id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }
    }
}
