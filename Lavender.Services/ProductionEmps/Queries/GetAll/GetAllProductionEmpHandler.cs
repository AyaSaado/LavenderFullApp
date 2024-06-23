using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Lavender.Services.ProductionEmps
{
    public class GetAllProductionEmpHandler : IRequestHandler<GetAllProductionEmpRequest, List<ProductionEmpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductionEmpHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductionEmpResponse>> Handle(GetAllProductionEmpRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductionEmps
                                             .GetAll()
                                             .Select(ProductionEmpResponse.Selector())
                                             .ToListAsync(cancellationToken);

            return result;
        }
    }
}
