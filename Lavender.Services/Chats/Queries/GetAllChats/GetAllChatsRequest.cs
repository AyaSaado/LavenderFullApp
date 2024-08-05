using MediatR;

namespace Lavender.Services.Chats
{
    public class GetAllChatsRequest : IRequest<List<ChatResponse>>
    {
        public Guid UserId {  get; set; } 
    }
    public class ChatResponse
    {
        public int Id { get; set; }
        public int DesignId { get; set; }
        public string ItemName { get; set; }
        public Guid FromUser { get; set; } 
        public string? LastMessage { get; set; }
    }
}
