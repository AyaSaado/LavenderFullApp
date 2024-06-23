using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Lavender.Services.PatternMakers
{
    public class GetAllPatternMakerHandler : IRequestHandler<GetAllPatternMakerRequest, List<PatternMakerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatternMakerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PatternMakerResponse>> Handle(GetAllPatternMakerRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.PatternMakers.GetAll()
                                                        .Select(PatternMakerResponse.Selector())
                                                        .ToListAsync(cancellationToken);

           
            return result;
        }
    }
}
