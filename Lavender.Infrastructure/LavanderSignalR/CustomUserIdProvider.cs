using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Lavender.Infrastructure.LavanderSignalR
{
    public class CustomUserIdProvider : IUserIdProvider
    {
  
        public List<string>? GetUsersId(HubConnectionContext connection)
        {
            var connectedUserIds = connection.User?.Claims
                                  .Where(claim => claim.Type == ClaimTypes.NameIdentifier)
                                  .Select(claim => claim.Value)
                                  .ToList();


            return connectedUserIds;
        }

        string? IUserIdProvider.GetUserId(HubConnectionContext connection)
        {
            throw new NotImplementedException();
        }
    }
}
