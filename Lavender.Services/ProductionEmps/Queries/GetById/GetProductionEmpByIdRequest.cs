

using Lavender.Core.Shared;
using MediatR;


namespace Lavender.Services.ProductionEmps
{
    public class GetProductionEmpByIdRequest : IRequest<Result<ProductionEmpResponse>>
    {
        public Guid Id { get; set; }
    }
}
