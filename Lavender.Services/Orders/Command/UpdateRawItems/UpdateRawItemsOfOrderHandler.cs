

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class UpdateRawItemsOfOrderHandler : IRequestHandler<UpdateRawItemsOfOrderRequest, bool>
    {
        private readonly ICRUDRepository<Consuming> _consumingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRawItemsOfOrderHandler(IUnitOfWork unitOfWork, ICRUDRepository<Consuming> consumingRepository)
        {
            _unitOfWork = unitOfWork;
            _consumingRepository = consumingRepository;
        }

        public async Task<bool> Handle(UpdateRawItemsOfOrderRequest request, CancellationToken cancellationToken)
        {
            var consumingDtoIds = request.ConsumingDtos.Select(dto => dto.Id);

            var entitiesInDB = await _consumingRepository.Find(c => consumingDtoIds.Contains(c.Id))
                                                         .ToListAsync(cancellationToken);

            if (request.ConsumingDtos.Count != entitiesInDB.Count)
                return false;

            for (int i = 0; i < request.ConsumingDtos.Count; i++)
            {
                Mapping.Mapper.Map(request.ConsumingDtos[i], entitiesInDB[i]);
            }

            try
            {
                 _consumingRepository.UpdateRange(entitiesInDB);
                await _unitOfWork.Save(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
