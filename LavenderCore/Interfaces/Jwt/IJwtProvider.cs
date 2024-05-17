
using Lavender.Core.Entities;
using Microsoft.IdentityModel.Tokens;


namespace Lavender.Core.Interfaces.Jwt
{
    public interface IJwtProvider
    {
        SecurityToken Generate(User user , List<string> roles);
    }
}
