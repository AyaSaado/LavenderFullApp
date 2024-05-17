
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;

namespace Lavender.Infrastructure.Repository
{
    public class PatternMakerRepository : CRUDRepository<PatternMaker>, IPatternMakerRepository
    {
        public PatternMakerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
