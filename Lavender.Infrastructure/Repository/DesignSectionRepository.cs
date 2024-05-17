

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;

namespace Lavender.Infrastructure.Repository
{
    public class DesignSectionRepository : CRUDRepository<DesigningSection>, IDesignSectionRepository
    {
        public DesignSectionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
