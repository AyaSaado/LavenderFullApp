using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;

namespace Lavender.Infrastructure.Repository
{
    public class DesignRepository : CRUDRepository<Design>, IDesignRepository
    {
        public DesignRepository(AppDbContext context) : base(context)
        {
        }
    }
}
