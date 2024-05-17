

using MediatR;
using Lavender.Core.Shared;
using Lavender.Services.Users.Commands.Login;

namespace Lavender.Services.Users.Commands.RefreshToken
{
    public class RefreshTokenRequest : IRequest<Result<TokenRequest.Respone>>
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }

    }
}
