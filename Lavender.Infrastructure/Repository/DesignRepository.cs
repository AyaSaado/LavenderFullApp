using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lavender.Infrastructure.Repository
{
    public class DesignRepository : CRUDRepository<Design>, IDesignRepository
    {
        public DesignRepository(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<Design> Find(Expression<Func<Design, bool>> predicate)
        {
            return base.Find(predicate)
                       .Include(d => d.DesignImages)
                       .Include(d => d.Chats);
                       
                   
        }

        public override IQueryable<Design> GetAll(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            return base.GetAll(pageNumber, pageSize)
                       .Include(d => d.DesignImages)
                       .Include(d => d.Chats);
        }

        public override Task<Design?> GetOneAsync(Expression<Func<Design, bool>> predicate, CancellationToken cancellationToken)
        {
            return base.Find(predicate)
                       .Include(d => d.DesignImages)
                       .Include(d => d.Chats)
                       .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
