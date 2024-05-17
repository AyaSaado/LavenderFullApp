

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;

namespace Lavender.Infrastructure.Repository
{
    public class MakerSectionRepository : CRUDRepository<MakerSection>, IMakerSectionRepository
    {
        public MakerSectionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
