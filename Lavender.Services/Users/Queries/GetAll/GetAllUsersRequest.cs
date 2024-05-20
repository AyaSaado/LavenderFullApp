using Lavender.Core.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lavender.Services.Users.Queries.GetAll.GetAllUsersRequest;

namespace Lavender.Services.Users.Queries.GetAll
{
    public class GetAllUsersRequest : IRequest<List<UserResponse>>
    {
        public string? Role { get; set; }

        public class UserResponse
        {
            public Guid Id { get; set; }
            public string? ProfileImageUrl { get; set; }
            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string UserName { get; set; } = null!;
            public string? PhoneNumber { get; set; } = null!;
            public string? NationalNumber { get; set; }
            public string? Address { get; set; }
            public DateOnly BirthDay { get; set; }

            public static Expression<Func<User, UserResponse>> Selector() => p
               => new()
               {
                   Id = p.Id,
                   FullName = p.FullName,
                   Email = p.Email!,
                   UserName = p.UserName!,
                   BirthDay = p.BirthDay,
                   NationalNumber = p.NationalNumber,
                   PhoneNumber = p.PhoneNumber,
                   Address = p.Address,
                   ProfileImageUrl = p.ProfileImageUrl,
                   
               };

        }
    }
}
