using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace Lavender.Infrastructure.LavanderSignalR
{
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {
        public static Dictionary<string, string> _userConnectionMap = new Dictionary<string, string>();
        public static Dictionary<string, Dictionary<string, int>> _runTimeUnreadMessages = new Dictionary<string, Dictionary<string, int>>();
        public static ConcurrentDictionary<string, List<string>> _chatGroups = new ConcurrentDictionary<string, List<string>>();

        public async Task ConnectToChat(int chatId)
        {
            var user = Context.User;

            if (user!.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
 
                await AddUserToChat(chatId.ToString(), userId!);
            }   
        }
        public async Task DisconnectedFromChat(int chatId)
        {
            var user = Context.User;

            if (user!.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Get the chat group associated with the chat ID
             
                await RemoveUserFromChat(chatId.ToString(), userId!);
            }
        }
        public async Task AddUserToChat(string chatId , string userId)
        {
            // Create a new chat group if it doesn't already exist
               _chatGroups.AddOrUpdate(chatId,
                                new List<string> { userId },
                                (key, existingObjects) =>
                                {
                                    existingObjects.Add(userId);
                                    return existingObjects;
                                });

            await Task.CompletedTask;
        }

        public async Task RemoveUserFromChat(string chatId, string userId)
        {
            // Remove the user from the chat group if it exists
            _chatGroups.AddOrUpdate(chatId,
                      new List<string>(),
                      (key, existingObjects) =>
                      {
                          existingObjects.Remove(userId);
                          return existingObjects;
                      });

            await Task.CompletedTask;
        }

        public override async Task OnConnectedAsync()
        {
            var user = Context.User;

            if (user!.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _userConnectionMap[userId!] = Context.ConnectionId;

                if (_runTimeUnreadMessages.TryGetValue(userId!, out var ChatsWithCounts))
                {
                    foreach (var chatWithCount in ChatsWithCounts)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveMessagesCount(chatWithCount.Key, chatWithCount.Value);
                    }

                    // Reset the unread message counts for all chats to 0
                    _runTimeUnreadMessages[userId!] = new Dictionary<string, int>();
                }

                await base.OnConnectedAsync();
            }
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = Context.User;
            if (user!.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Remove the userId from the connection map
                if (_userConnectionMap.ContainsKey(userId!))
                {
                    _userConnectionMap.Remove(userId!);
                }

                await base.OnDisconnectedAsync(exception);
            }
        }


    }
}
