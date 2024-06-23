using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Orders
{
    public class AddFeedBackHandler : IRequestHandler<AddFeedBackRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFeedBackHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddFeedBackRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOneAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order == null)
            {
                return false;
            }

            order.Feedback = request.FeedBack;

            try
            {
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Save(cancellationToken);
                return true;
            }
            catch(Exception) 
            {
                return false;
            }

        }
    }
}
