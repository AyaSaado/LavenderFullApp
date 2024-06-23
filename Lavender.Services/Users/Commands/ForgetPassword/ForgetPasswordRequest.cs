
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Services.Users
{
    public class ForgetPasswordRequest : IRequest<string>
    {
        [Required]
        public required string Email { get; set; } 
    }
}
