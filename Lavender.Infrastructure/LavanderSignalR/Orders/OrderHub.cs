using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace Lavender.Infrastructure.LavanderSignalR
{
    [Authorize]
    public  class OrderHub : Hub<IOrderHub>
    {

        public static Dictionary<string, string> _userConnectionMap = new Dictionary<string, string>();
        public static ConcurrentDictionary<string, List<string>> _runtimeAddObjects = new ConcurrentDictionary<string, List<string>>();
        public static ConcurrentDictionary<string, Dictionary<int,string>> _runtimeAddFeedBack = new ConcurrentDictionary<string, Dictionary<int, string>>();
        public static ConcurrentDictionary<string, List<string>> _runtimeAddObjectsToProd = new ConcurrentDictionary<string, List<string>>();
        public static ConcurrentDictionary<string, List<string>> _runtimeUpdateObjects = new ConcurrentDictionary<string, List<string>>();
        public static ConcurrentDictionary<string, List<string>> _runtimeDeleteObjects = new ConcurrentDictionary<string, List<string>>();
        public static ConcurrentDictionary<string, Dictionary<int, string>> _runtimeFinishedObjects = new ConcurrentDictionary<string, Dictionary<int, string>>();

        public override async Task OnConnectedAsync()
        {
            var user = Context.User;
            if (user!.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var role = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;

                // Store the user ID and role in the connected user's group
                await Groups.AddToGroupAsync(Context.ConnectionId, role!);
               
                _userConnectionMap[userId!] = Context.ConnectionId;

                if (_runtimeAddObjects.TryGetValue(userId!, out List<string>? orders))
                {
                    // Send the orders to the connected user
                    foreach (var order in orders)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveOrderCreated(order);
                    }

                    // Remove the orders from _runtimeAddObjects since they have been received
                    _runtimeAddObjects.TryRemove(userId!, out _);
                }

                if (_runtimeAddFeedBack.TryGetValue(userId!, out Dictionary<int,string>? feedbacks))
                {
                    // Send the feedbacks to the connected user
                    foreach (var feedback in feedbacks)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveFeedBackOfOrder(feedback.Key , feedback.Value);
                    }

                    // Remove the orders from _runtimeAddFeedBack since they have been received
                    _runtimeAddFeedBack.TryRemove(userId!, out _);
                }

                if (_runtimeAddObjectsToProd.TryGetValue(userId!, out List<string>? prod_orders))
                {
                    // Send the orders to the connected user
                    foreach (var order in prod_orders)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveOrderToProduction(order);
                    }

                    // Remove the orders from _runtimeAddObjectsToProd since they have been received
                    _runtimeAddObjectsToProd.TryRemove(userId!, out _);
                }

                if (_runtimeUpdateObjects.TryGetValue(userId!, out List<string>? updated_orders))
                {
                    // Send the orders to the connected user
                    foreach (var order in updated_orders)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveOrderUpdated(order);
                    }

                    // Remove the orders from _runtimeUpdateObjects since they have been received
                    _runtimeUpdateObjects.TryRemove(userId!, out _);
                }

                if (_runtimeDeleteObjects.TryGetValue(userId!, out List<string>? deletemessages))
                {
                    // Send the deletemessages to the connected user
                    foreach (var deletemessage in deletemessages)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveOrderDeleted(deletemessage);
                    }

                    // Remove the orders from _runtimeDeleteObjects since they have been received
                    _runtimeDeleteObjects.TryRemove(userId!, out _);
                }


                if (_runtimeFinishedObjects.TryGetValue(userId!, out Dictionary<int,string>? messages))
                {
                    // Send the messages to the connected user
                    foreach (var deletemessage in messages)
                    {
                        await Clients.Client(Context.ConnectionId).ReceiveOrderFinished(deletemessage.Key , deletemessage.Value);
                    }

                    // Remove the orders from _runtimeFinishedObjects since they have been received
                    _runtimeFinishedObjects.TryRemove(userId!, out _);
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
                var role = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;

                // Remove the user from the appropriate group when disconnected
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, role!);

                // Remove the userId from the connection map
                if (_userConnectionMap.ContainsKey(userId!))
                {
                    _userConnectionMap.Remove(userId!);
                }

                await base.OnDisconnectedAsync(exception);
            }
        }
        //// Not Accessed ^_^
        //public async Task SendOrderCreated(string groupName,string order)
        //{
        //    await Clients.Group(groupName).ReceiveOrderCreated(order);
        //}

        //public async Task SendOrderUpdated(string groupName,string productionId, string order)
        //{
        //    await Clients.Group(groupName).ReceiveOrderCreated(order);

        //    if (_userConnectionMap.TryGetValue(productionId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).ReceiveOrderToProduction(order);
        //    }
        //}

        //public async Task SendOrderToProduction(string userId, string order)
        //{
        //    if (_userConnectionMap.TryGetValue(userId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).ReceiveOrderToProduction(order);
        //    }
        //}

        //public async Task SendFeedBackOfOrder(string userId ,string groupName ,string message)
        //{
        //    if (_userConnectionMap.TryGetValue(userId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).ReceiveFeedBackOfOrder(message);
        //    }
        //        await Clients.Group(groupName).ReceiveFeedBackOfOrder(message);
        //}

        //public async Task SendOrderDeleted(string groupName , string message)
        //{
        //    await Clients.Group(groupName).ReceiveOrderDeleted(message);
        //}

        //public async Task SendOrderFinished(string userId, string message)
        //{
        //    if (_userConnectionMap.TryGetValue(userId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).ReceiveOrderFinished(message);
        //    }
        //}
    }
}
