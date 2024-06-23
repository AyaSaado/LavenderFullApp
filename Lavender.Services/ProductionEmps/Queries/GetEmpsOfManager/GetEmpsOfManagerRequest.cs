using MediatR;


namespace Lavender.Services.ProductionEmps
{
    public class GetEmpsOfManagerRequest : IRequest<List<ProductionEmpResponse>>
    {
        public Guid ManagerId { get; set; }
    }
}
