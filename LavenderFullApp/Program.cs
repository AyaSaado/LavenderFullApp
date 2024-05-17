using Lavender.Core.Entities;
using Lavender.Services;
using Lavender.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Lavender.Infrastructure;
using LavenderFullApp.Seed;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.AddRegiteration();

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

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/DashBoard/swagger.json", "DashBoard");
    c.SwaggerEndpoint("/swagger/MobileApp/swagger.json", "MobileApp");
    c.SwaggerEndpoint("/swagger/Common/swagger.json", "Common");
});
app.UseStaticFiles();

//app.UseCors("Policy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();

await SeedData.Seed(app);

app.Run();
