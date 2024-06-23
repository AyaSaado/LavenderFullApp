

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Lavender.Infrastructure.Jwt
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _configuration;
        private const string Jwt = "Jwt";
        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(Jwt).Bind(options);
        }
    }
}
