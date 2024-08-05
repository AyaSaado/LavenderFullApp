
using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Lavender.Services.Chats.Queries.GetMessagesOfChat
{
    public class GetMessagesOfChatRequest : IRequest<List<MessageResponse>>
    {
        public int ChatId {  get; set; }
    }
    public class MessageResponse
    {
        public int Id { get; set; }
        public Guid Sender_Id { get; set; }
        public string? Content { get; set; }
        public string? URL { get; set; }
        public DateTime SentTime { get; set; }
        public static Expression<Func<Message, MessageResponse>> Selector() => o
             => new()
             {
                Id = o.Id,
                Content = o.Content,
                Sender_Id = o.Sender_Id,
                SentTime = o.SentTime,
                URL = o.URL,

             };
    }
}
