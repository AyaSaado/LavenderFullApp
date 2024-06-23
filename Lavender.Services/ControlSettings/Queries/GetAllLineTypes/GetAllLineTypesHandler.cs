using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Lavender.Services.ControlSettings
{
    public class GetAllLineTypesHandler : IRequestHandler<GetAllLineTypesRequest, List<LineTypeResponse>>
    {

        private readonly ICRUDRepository<LineType> _lineTyperepository;

        public GetAllLineTypesHandler(ICRUDRepository<LineType> lineTyperepository)
        {
            _lineTyperepository = lineTyperepository;
        }

        public async Task<List<LineTypeResponse>> Handle(GetAllLineTypesRequest request, CancellationToken cancellationToken)
        {
            var result = await _lineTyperepository.GetAll()
                                                  .Select(LineTypeResponse.Selector())
                                                  .ToListAsync(cancellationToken);
            return result;
        }
    }
}
