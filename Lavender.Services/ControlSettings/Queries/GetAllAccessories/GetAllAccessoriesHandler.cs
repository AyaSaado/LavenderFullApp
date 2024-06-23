using AutoMapper;
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetAllAccessoriesHandler : IRequestHandler<GetAllAccessoriesRequest, List<ControlData>>
    {
        private readonly ICRUDRepository<Accessory> _accessoryRepository;
        private readonly IMapper _mapper;

        public GetAllAccessoriesHandler(ICRUDRepository<Accessory> accessoryRepository, IMapper mapper)
        {
            _accessoryRepository = accessoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ControlData>> Handle(GetAllAccessoriesRequest request, CancellationToken cancellationToken)
        {
            var result = await _accessoryRepository.GetAll().ToListAsync(cancellationToken);


            return _mapper.Map<List<ControlData>>(result);
        }
    }
}
