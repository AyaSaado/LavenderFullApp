using System.Linq.Expressions;

namespace Lavender.Core.Interfaces.Repository
{
    public interface ICRUDRepository<T> where T : class
    {
        IQueryable<T> GetAll(int pageNumber = 1, int pageSize = int.MaxValue);
        Task<T?> GetOneAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken);
      //  Task<TResult?> GetOneAsync(Expression<Func<T, bool>> filter, Expression<Func<T, T>> selector);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Update(T entity);
        bool UpdateRange(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);


    }
}
