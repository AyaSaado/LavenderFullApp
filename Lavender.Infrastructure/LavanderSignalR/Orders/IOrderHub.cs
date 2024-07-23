

namespace Lavender.Infrastructure.LavanderSignalR
{
    public interface IOrderHub
    {
       Task ReceiveOrderCreated(string order);
       Task ReceiveOrderUpdated(string order);
       Task ReceiveFeedBackOfOrder(string message);
       Task ReceiveOrderToProduction(string order);
       Task ReceiveOrderDeleted(string message);
    }
}
