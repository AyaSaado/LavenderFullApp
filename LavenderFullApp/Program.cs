using Lavender.Core.Entities;
using Lavender.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Lavender.Infrastructure;
using LavenderFullApp.Seed;
using static Lavender.Core.Helper.MappingProfile;
using Lavender.Services;
using LavenderFullApp.Localization;
using Microsoft.Extensions.Localization;
using Lavender.Infrastructure.LavanderSignalR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLocalization();

builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

builder.Services.AddMvc()
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    factory.Create(typeof(JsonStringLocalizerFactory));
});

builder.Services.AddSwaggerGen(o =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {

        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "input Token without **Bearer**",

        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        }
    };
    
        o.SwaggerDoc("DashBoard", new OpenApiInfo
        {
            Title = "DashBoard",
            Version = "v1"
        });
        o.SwaggerDoc("MobileApp", new OpenApiInfo
        {
            Title = "MobileApp",
            Version = "v2"
        });
        o.SwaggerDoc("Common", new OpenApiInfo
        {
            Title = "Common",
            Version = "v3"
        });

        o.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        o.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });

});

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("LavenderFullApp"));
    if (!builder.Environment.IsProduction())
    {
        o.EnableSensitiveDataLogging();
    }
})
.AddIdentity<User, IdentityRole<Guid>>(
    options =>
    {
        options.Password.RequireNonAlphanumeric = false;
    }
  )
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSignalR(options => options.EnableDetailedErrors = true);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

builder.AddRegiteration();

builder.Services.AddScoped<HandlerServices>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(o =>
{
    o.AddPolicy("Policy", policyBuilder =>
    {
        policyBuilder
        .WithOrigins("http://localhost:5500")
         .AllowAnyHeader()
           .AllowAnyMethod()
            .AllowCredentials();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/DashBoard/swagger.json", "DashBoard");
    c.SwaggerEndpoint("/swagger/MobileApp/swagger.json", "MobileApp");
    c.SwaggerEndpoint("/swagger/Common/swagger.json", "Common");
});

app.UseStaticFiles();
app.UseCors("Policy");

var supportedCultures = new[] { "ar-SA", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1])
    .AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(end =>
{
    end.MapControllers();
    end.MapHub<OrderHub>("/OrderHub");
    end.MapHub<ChatHub>("/ChatHub");
});

await SeedData.Seed(app);

app.Run();
