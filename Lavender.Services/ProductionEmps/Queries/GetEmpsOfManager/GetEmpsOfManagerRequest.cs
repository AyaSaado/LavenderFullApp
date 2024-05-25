using MediatR;
using static Lavender.Services.ProductionEmps.Queries.GetAll.GetAllProductionEmpRequest;

namespace Lavender.Services.ProductionEmps.Queries.GetEmpsOfManager
{
    public class GetEmpsOfManagerRequest : IRequest<List<ProductionEmpResponse>>
    {
        public Guid ManagerId { get; set; }
    }
}
