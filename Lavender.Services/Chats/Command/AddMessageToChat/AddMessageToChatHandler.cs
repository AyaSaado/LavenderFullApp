using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.LavanderSignalR;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lavender.Services.Chats
{
    public class AddMessageToChatHandler : IRequestHandler<AddMessageToChatRequest, bool>
    {
        private readonly ICRUDRepository<Chat> _chatRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        private readonly IHubContext<ChatHub, IChatHub> _chatHubContext;
        public AddMessageToChatHandler(IUnitOfWork unitOfWork, ICRUDRepository<Chat> chatRepository, IFileServices fileServices, IHubContext<ChatHub, IChatHub> chatHubContext)
        {
            _unitOfWork = unitOfWork;
            _chatRepository = chatRepository;
            _fileServices = fileServices;
            _chatHubContext = chatHubContext;
        }

        public async Task<bool> Handle(AddMessageToChatRequest request, CancellationToken cancellationToken)
        {
           var chat = await _chatRepository.Find(c=>c.Id == request.ChatId)
                                           .Include(c=>c.Design)
                                           .ThenInclude(d=>d.Order)
                                           .FirstOrDefaultAsync(cancellationToken);

            if (chat is null)
                return false;

            chat.Messages.Add(new Message()
            {
                ChatId = request.ChatId,
                Content = request.Content,
                URL = await _fileServices.Upload(request.Image),
                Sender_Id = request.Sender_Id,
                SentTime = request.SentTime
            });

            try
            {
                _chatRepository.Update(chat);
                await _unitOfWork.Save(cancellationToken);

                var message = chat.Messages.OrderByDescending(m => m.SentTime)
                                           .First();

                var jsonMessage = JsonConvert.SerializeObject(message, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.None // Optional: for pretty-printing the JSON
                });

                var designer = chat.Design.DesignerId;

                var actor = chat.Design.Order.ActorId;

                var receiver = (designer != message.Sender_Id) ? designer.ToString() : actor.ToString();

                var Getchat = ChatHub._chatGroups.TryGetValue(chat.Id.ToString(), out var OnlineUsers);
                
                if (Getchat && OnlineUsers != null && OnlineUsers.Contains(receiver))
                {
                    var connectionId = ChatHub._userConnectionMap[receiver];

                    await _chatHubContext.Clients.Client(connectionId).ReceiveMessage(jsonMessage);
                }
                else
                {
                    if (ChatHub._userConnectionMap.TryGetValue(receiver, out var connectionId))
                    {
                        await _chatHubContext.Clients.Client(connectionId).ReceiveMessagesCount(chat.Id.ToString() , 1);
                    }
                    else
                    {
                        if (ChatHub._runTimeUnreadMessages.TryGetValue(receiver, out var ChatsWithCounts))
                        {
                            if (ChatsWithCounts.TryGetValue(chat.Id.ToString(), out var unreadCount))
                            {
                                ChatHub._runTimeUnreadMessages[receiver][chat.Id.ToString()] = unreadCount + 1; // Increment the unread message count for the specific chat
                            }
                            else
                            {
                                ChatHub._runTimeUnreadMessages[receiver][chat.Id.ToString()] = 1; // Initialize the unread message count if it doesn't exist
                            }
                        }
                        else
                        {
                            ChatHub._runTimeUnreadMessages[receiver] = new Dictionary<string, int> { { chat.Id.ToString(), 1 } }; // Create a new entry for the specific chat
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
