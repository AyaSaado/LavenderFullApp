using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Jwt;
using Lavender.Core.Interfaces.Repository;
using Lavender.Infrastructure.Files;
using Lavender.Infrastructure.Jwt;
using Lavender.Infrastructure.Repository;
using Lavender.Core.Helper;


namespace Lavender.Infrastructure
{
    public static class ServicesRegiteration
    {
        public static void AddRegiteration(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
            builder.Services.ConfigureOptions<JwtOptionsSetup>();
            builder.Services.ConfigureOptions<JwtBearerOptiosSetup>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddTransient<IEmailRepository,EmailRepository>();
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
           // builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context => {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken)
                            && path.StartsWithSegments("/OrderHub"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        }
     }
}
