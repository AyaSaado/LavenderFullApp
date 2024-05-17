
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Services.Users.Commands.ForgetPassword
{
    public class ForgetPasswordRequest : IRequest<string>
    {
        [Required]
        public required string Email { get; set; } 
    }
}
