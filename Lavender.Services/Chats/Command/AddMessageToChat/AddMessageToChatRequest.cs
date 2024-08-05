using MediatR;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.Chats
{
    public class AddMessageToChatRequest : IRequest<bool>
    {
        public int ChatId { get; set; }
        public Guid Sender_Id { get; set; }
        public string? Content { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime SentTime { get; set; }
    }
}
