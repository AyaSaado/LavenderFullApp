
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ProductionEmps
{
    public class GetProductionEmpByIdHandler : IRequestHandler<GetProductionEmpByIdRequest, Result<ProductionEmpResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductionEmpByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProductionEmpResponse>> Handle(GetProductionEmpByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ProductionEmps.Find(p => p.Id == request.Id)
                                                         .Select(ProductionEmpResponse.Selector())
                                                         .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return Result.Failure<ProductionEmpResponse>(new Error("404", "User Is Not Found"));
            }

            return entity;
        }
    }
}
