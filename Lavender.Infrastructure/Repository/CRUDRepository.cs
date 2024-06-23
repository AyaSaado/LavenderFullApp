using Lavender.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Lavender.Core.Interfaces.Repository;
using System.Linq.Expressions;

namespace Lavender.Infrastructure.Repository
{
   
    public class CRUDRepository<T> : ICRUDRepository<T> where T: class
    {
        protected readonly AppDbContext _context;

        public CRUDRepository(AppDbContext context)
        {
            _context = context;
        }
        public virtual  IQueryable<T> GetAll(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            int skipCount = (pageNumber - 1) * pageSize;

            return  _context.Set<T>()
                .Skip(skipCount)
                .Take(pageSize);
        }

        public virtual async Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetAll().Where(predicate).FirstOrDefaultAsync(cancellationToken);
        }
        public  virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return  GetAll().Where(predicate);
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Update(T entity)
        {
            try
            {
                 _context.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

           
        }
        public virtual bool UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                foreach(var entity in entities)
                {
                    _context.Update(entity);
                   
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

           
        }
        public virtual bool Remove(T entity)
        {
            try
            {
                 _context.Remove(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _context.RemoveRange(entities);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
