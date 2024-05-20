﻿using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Microsoft.AspNetCore.Http;

namespace Lavender.Services.Users.Commands.Update
{
    public class UpdateUserRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public IFormFile? ProfileImage { get; set; }
        public string? NationalNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateOnly BirthDay { get; set; }
        public string? Address { get; set;}
        public string? Role { get; set; } 
    }

        

}
