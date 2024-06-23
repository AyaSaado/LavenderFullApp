using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.PatternMakers
{
    public class GetPatternMakerByIdHandler : IRequestHandler<GetPatternMakerByIdRequest, Result<PatternMakerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatternMakerByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PatternMakerResponse>> Handle(GetPatternMakerByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PatternMakers.Find(p => p.Id == request.Id)
                                                        .Select(PatternMakerResponse.Selector())
                                                        .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return Result.Failure<PatternMakerResponse>(new Error("404", "User Is Not Found"));
            }

            return entity;
        }
    }
}
