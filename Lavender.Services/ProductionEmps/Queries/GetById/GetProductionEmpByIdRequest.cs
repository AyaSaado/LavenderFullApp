

using Lavender.Core.Shared;
using MediatR;
using static Lavender.Services.ProductionEmps.Queries.GetAll.GetAllProductionEmpRequest;

namespace Lavender.Services.ProductionEmps.Queries.GetById
{
    public class GetProductionEmpByIdRequest : IRequest<Result<ProductionEmpResponse>>
    {
        public Guid Id { get; set; }
    }
}
