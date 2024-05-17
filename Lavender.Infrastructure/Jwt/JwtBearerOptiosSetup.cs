

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Lavender.Infrastructure.Jwt
{
    internal class JwtBearerOptiosSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptiosSetup(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        //public void Configure(JwtBearerOptions options)
        //{
        //    //options.TokenValidationParameters = new()
        //    //{
        //    //    ValidateIssuerSigningKey = true,
        //    //    ValidateIssuer = false, // for dev
        //    //    ValidateAudience = false, // for dev 
        //    //    RequireExpirationTime = true, 
        //    //    ValidateLifetime = true,                
        //    //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
        //    //};
        //    options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
        //    options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
        //    options.TokenValidationParameters.IssuerSigningKey =
        //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        //}

        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
            options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
            options.TokenValidationParameters.IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        }
    }
}
