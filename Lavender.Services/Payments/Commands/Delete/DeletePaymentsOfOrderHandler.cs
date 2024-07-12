

using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Payments
{
    public  class DeletePaymentsOfOrderHandler : IRequestHandler<DeletePaymentsOfOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Payment> _paymentRepository;
        public DeletePaymentsOfOrderHandler(IUnitOfWork unitOfWork, ICRUDRepository<Payment> paymentRepository)
        {
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
        }

       
        public async Task<bool> Handle(DeletePaymentsOfOrderRequest request, CancellationToken cancellationToken)
        {

            var entities = await _paymentRepository
                                  .Find(p => request.Ids.Contains(p.Id))
                                  .ToListAsync(cancellationToken);

            try
            {
                _paymentRepository.RemoveRange(entities);
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
