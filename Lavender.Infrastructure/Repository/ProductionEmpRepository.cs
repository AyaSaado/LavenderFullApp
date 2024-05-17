
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Data;

namespace Lavender.Infrastructure.Repository
{
    public class ProductionEmpRepository : CRUDRepository<ProductionEmp>, IProductionEmpRepository
    {
        public ProductionEmpRepository(AppDbContext context) : base(context)
        {
        }
    }
}
