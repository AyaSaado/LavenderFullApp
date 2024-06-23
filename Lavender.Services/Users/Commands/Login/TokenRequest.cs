

using MediatR;
using Lavender.Core.Shared;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Services.Users
{
    public class TokenRequest 
    {
        public class Request : IRequest<Result<Respone>>
        {
            [Required]
            public required string UserName {  get; set; }
            
            [Required]
            public required string Password {  get; set; }
        }

        public class Respone
        {  

            public string Token { get; set; } = string.Empty;
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
