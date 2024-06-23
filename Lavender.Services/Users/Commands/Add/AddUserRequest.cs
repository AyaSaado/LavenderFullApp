using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.Users
{
    public class AddUserRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public IFormFile? ProfileImage { get; set; }
        public  string Email { get; set; } = null!;
        public  string UserName { get; set; } = null!;
        public  string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? NationalNumber { get; set; }
        public DateOnly BirthDay { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = null!;
    }



}
