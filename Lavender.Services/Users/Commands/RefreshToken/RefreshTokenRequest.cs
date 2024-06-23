

using MediatR;
using Lavender.Core.Shared;

namespace Lavender.Services.Users
{
    public class RefreshTokenRequest : IRequest<Result<TokenRequest.Respone>>
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }

    }
}
