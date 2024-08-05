
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lavender.Services.Chats
{
    public class GetAllChatsHandler : IRequestHandler<GetAllChatsRequest, List<ChatResponse>>
    {
        private readonly ICRUDRepository<Chat> _chatRepository;

        public GetAllChatsHandler(ICRUDRepository<Chat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<ChatResponse>> Handle(GetAllChatsRequest request, CancellationToken cancellationToken)
        {
            var chats = await _chatRepository.Find(c => c.Design.DesignerId == request.UserId 
                                                   || c.Design.Order.ActorId == request.UserId)
                                            .Include(c => c.Design)
                                            .ThenInclude(d => d.Order)
                                            .ThenInclude(o=>o.Item)
                                            .ToListAsync(cancellationToken);

            var results = new List<ChatResponse>();

            foreach(var chat in chats)
            {
                var lastmessage = chat.Messages.OrderByDescending(m => m.SentTime).Select(m => m.Content).FirstOrDefault();
               
                if(lastmessage.IsNullOrEmpty() && chat.Messages.Any())
                {
                    lastmessage = chat.Messages.OrderByDescending(m => m.SentTime).Select(m => m.URL).FirstOrDefault();
                }
                
                results.Add(new ChatResponse()
                {
                    Id= chat.Id,
                    DesignId = chat.DesignId,
                    ItemName = chat.Design.Order.Item.Name,
                    FromUser = request.UserId == chat.Design.DesignerId ? chat.Design.Order.ActorId : chat.Design.DesignerId,
                    LastMessage = lastmessage
                    
                }) ;
            }

            return results;
        }
    }
}
