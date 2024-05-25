using Lavender.Core.Shared;
using MediatR;
using static Lavender.Services.PatternMakers.Queries.GetAll.GetAllPatternMakerRequest;

namespace Lavender.Services.PatternMakers.Queries.GetById
{
    public class GetPatternMakerByIdRequest : IRequest<Result<PatternMakerResponse>>
    {
        public Guid Id { get; set; }
    }
}
