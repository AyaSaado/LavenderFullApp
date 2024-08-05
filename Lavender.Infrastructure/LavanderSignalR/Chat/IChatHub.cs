
namespace Lavender.Infrastructure.LavanderSignalR
{
    public interface IChatHub
    {
        Task ReceiveMessage(string message);
        Task ReceiveMessagesCount (string chatId,int count);
    }
}
