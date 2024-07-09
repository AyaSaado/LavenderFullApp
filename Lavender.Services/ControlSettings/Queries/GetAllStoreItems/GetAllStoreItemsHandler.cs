using AutoMapper;
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetAllStoreItemsHandler : IRequestHandler<GetAllStoreItemsRequest, List<ControlData>>
    {
        private readonly ICRUDRepository<StoreItem> _storeItemRepository;
        private readonly IMapper _mapper;

        public GetAllStoreItemsHandler(ICRUDRepository<StoreItem> storeItemRepository, IMapper mapper)
        {
            _storeItemRepository = storeItemRepository;
            _mapper = mapper;
        }

        public async Task<List<ControlData>> Handle(GetAllStoreItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _storeItemRepository.GetAll().ToListAsync(cancellationToken);


            return _mapper.Map<List<ControlData>>(result);
        }
    }
}
