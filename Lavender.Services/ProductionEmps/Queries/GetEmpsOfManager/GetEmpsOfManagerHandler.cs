using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Services.ProductionEmps.Queries.GetAll.GetAllProductionEmpRequest;

namespace Lavender.Services.ProductionEmps.Queries.GetEmpsOfManager
{
    public class GetEmpsOfManagerHandler : IRequestHandler<GetEmpsOfManagerRequest, List<ProductionEmpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmpsOfManagerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductionEmpResponse>> Handle(GetEmpsOfManagerRequest request, CancellationToken cancellationToken)
        {
            return  await _unitOfWork.ProductionEmps.Find(p => p.Head.Id == request.ManagerId)
                                                    .Select(ProductionEmpResponse.Selector())
                                                    .ToListAsync(cancellationToken);
        }
    }
}
