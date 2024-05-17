using Lavender.Core.EntityDto;
using MediatR;

namespace Lavender.Services.ProductionEmps.Queries.GetAll
{
    public class GetAllProductionEmpRequest : IRequest<List<ProductionEmpDto>>
    {

    }
}
