using Lavender.Core.Shared;
using MediatR;


namespace Lavender.Services.PatternMakers
{
    public class GetPatternMakerByIdRequest : IRequest<Result<PatternMakerResponse>>
    {
        public Guid Id { get; set; }
    }
}
