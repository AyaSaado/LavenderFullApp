using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Services.Users.Queries.GetAllMainUsers.GetAllUsersRequest;

namespace Lavender.Services.Users.Queries.GetAllMainUsers
{
    public class GetAllUsersRequest : IRequest<List<AllUserResponse>>
    {
        public string Role { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public class AllUserResponse
        {
            public Guid Id { get; set; }
            public string? ProfileImageUrl { get; set; }
            public string FullName { get; set; } = null!;
            public string Role { get; set; } = null!;

            public static Expression<Func<User, AllUserResponse>> Selector() => p
               => new()
               {
                   Id = p.Id,
                   FullName = p.FullName,
                   ProfileImageUrl = p.ProfileImageUrl,
                 
               };

        }
    }
}
