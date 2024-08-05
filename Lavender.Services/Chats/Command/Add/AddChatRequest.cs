using Lavender.Core.Enum;
using MediatR;

namespace Lavender.Services.Chats
{
    public class AddChatRequest : IRequest<bool>
    {
        public ChatType ChatType { get; set; }
        public int DesignId { get; set; }
      
    }
}
