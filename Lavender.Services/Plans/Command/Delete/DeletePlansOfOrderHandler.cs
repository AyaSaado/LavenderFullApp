
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Plans
{
    public class DeletePlansOfOrderHandler : IRequestHandler<DeletePlansOfOrderRequest, bool>
    {
        private readonly ICRUDRepository<Plan> _planRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePlansOfOrderHandler(ICRUDRepository<Plan> planRepository, IUnitOfWork unitOfWork)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePlansOfOrderRequest request, CancellationToken cancellationToken)
        {
            var entities = await _planRepository
                                  .Find(tr => request.Ids.Contains(tr.Id))
                                  .ToListAsync(cancellationToken);

            try
            {
                
                _planRepository.RemoveRange(entities);
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
