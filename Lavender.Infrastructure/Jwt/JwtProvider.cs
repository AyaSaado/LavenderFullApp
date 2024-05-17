
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Lavender.Core.Interfaces.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lavender.Core.Entities;

namespace Lavender.Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public SecurityToken Generate(User user, List<string> roles)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name , user.UserName!),
             };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var subject = new ClaimsIdentity(claims);

            subject.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            subject.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()));

            var Key = Encoding.UTF8.GetBytes(_options.Secret);

            var TokenDescripter = new SecurityTokenDescriptor()
            {
                Issuer = _options.Issuer ,
                Audience =_options.Audience  ,
                Subject = subject,
                Expires = DateTime.UtcNow.Add(_options.ExpireyTimeFrame),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)

            };

            return JwtTokenHandler.CreateToken(TokenDescripter);

        }
    }
}
