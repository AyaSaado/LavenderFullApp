using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;

namespace Lavender.Services.Users.Commands.Add
{
    public class AddUserRequest : IRequest<Result<UserDto>>
    {
            public Guid Id { get; set; }
            public required string FullName { get; set; }
            public required string Email { get; set; }
            public required string UserName { get; set; }
            public required string Password { get; set; }
            public string? PhoneNumber { get; set; }
            public string? NationalNumber { get; set; }
            public DateOnly BirthDay { get; set; }
            public required string Role { get; set; }
    }



}
