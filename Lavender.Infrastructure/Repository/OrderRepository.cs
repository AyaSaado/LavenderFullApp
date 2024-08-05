using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lavender.Infrastructure.Repository
{
    public class OrderRepository : CRUDRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return base.Find(predicate)
                       .Include(o => o.Consumings)
                         .ThenInclude(c => c.SItemType)
                       .Include(o => o.ItemSizes)
                         .ThenInclude(i => i.ItemSizeWithColors)
                        .Include(o => o.ItemSizes)
                        .ThenInclude(i => i.Plans);
        }

        public override IQueryable<Order> GetAll(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            return base.GetAll(pageNumber, pageSize)
                       .Include(o => o.Consumings)
                        .ThenInclude(c => c.SItemType)
                       .Include(o => o.ItemSizes)
                        .ThenInclude(i=>i.Plans)
                       .Include(o => o.ItemSizes)
                        .ThenInclude(i => i.ItemSizeWithColors); 
        }

        public override Task<Order?> GetOneAsync(Expression<Func<Order, bool>> predicate , CancellationToken cancellationToken)
        {
            return base.Find(predicate)
                       .Include(o => o.Consumings)
                          .ThenInclude(c => c.SItemType)
                          .ThenInclude(s => s.StoreItem)
                          .Include(o => o.Consumings)
                          .ThenInclude(c => c.SItemType)
                          .ThenInclude(s => s.SType)
                       .Include(o => o.ItemSizes)
                          .ThenInclude(i => i.ItemSizeWithColors)
                       .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
