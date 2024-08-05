
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Chats.Queries.GetMessagesOfChat
{
    public class GetMessagesOfChatHandler : IRequestHandler<GetMessagesOfChatRequest, List<MessageResponse>>
    {
        private readonly ICRUDRepository<Chat> _chatRepository;

        public GetMessagesOfChatHandler(ICRUDRepository<Chat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<MessageResponse>> Handle(GetMessagesOfChatRequest request, CancellationToken cancellationToken)
        {
           return await _chatRepository.Find(c=>c.Id == request.ChatId)
                                          .SelectMany(c=>c.Messages)
                                          .Select(MessageResponse.Selector())
                                          .ToListAsync(cancellationToken);
        }
    }
}
