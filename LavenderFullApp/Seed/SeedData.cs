using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace LavenderFullApp.Seed
{
    public class SeedData
    {
        public static async Task Seed(IApplicationBuilder app)
        {
            var services = app.ApplicationServices.CreateScope().ServiceProvider;
            var context = services.GetService<AppDbContext>()!;
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = services.GetRequiredService<UserManager<User>>();

            await SeedRoles(context, roleManager);
            await SeedUsers(context, userManager);
            await SeedLineType(context);
           
        }

        private static async Task SeedLineType(AppDbContext context)
        {
            if (context.LineType.Any()) return;

            var lines = new List<LineType>();


            lines.Add(new LineType()
            {
                Name = "T_Shirt"
            });
            lines.Add(new LineType()
            {
                Name = "Dress"
            });
            lines.Add(new LineType()
            {
                Name = "Cajwal"
            });

            await context.LineType.AddRangeAsync(lines);
            await context.SaveChangesAsync();
        }

        private static async Task SeedRoles(AppDbContext context, RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (roleManager.Roles.Any()) return;

            var Roles = Enum.GetValues(typeof(LavanderRoles)).Cast<LavanderRoles>().Select(a => a.ToString());
            foreach (var Role in Roles)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = Role });
            }
            await context.SaveChangesAsync();

        }
        private static async Task SeedUsers(AppDbContext context, UserManager<User> _userManager)
        {
            if (context.User.Any()) return;

            var admin = new User()
            {
                FullName = "Aya Saado",
                PhoneNumber = "555",
                Email = "admin1@gmail.com",
                UserName = "admoon",
            };

            await _userManager.CreateAsync(admin, "popPO1^_^");
            await _userManager.AddToRoleAsync(admin, nameof(LavanderRoles.Admin));

            var executive = new User()
            {
                FullName = "Jodi Jabr",
                PhoneNumber = "666",
                Email = "Executive1@gmail.com",
                UserName = "Executive",
            };

            await _userManager.CreateAsync(executive, "rorPO1^_^");
            await _userManager.AddToRoleAsync(executive, nameof(LavanderRoles.Executive));

            var designer = new PatternMaker()
            {
                FullName = "Hiba Ahmad",
                PhoneNumber = "777",
                Email = "Designer1@gmail.com",
                UserName = "Designer1",
            };
            await _userManager.CreateAsync(designer, "rorPO1^_^");
            await _userManager.AddToRoleAsync(designer, nameof(LavanderRoles.Designer));
            
            var tailor = new PatternMaker()
            {
                FullName = "Shahd Hizan",
                PhoneNumber = "888",
                Email = "Tailor1@gmail.com",
                UserName = "Tailor1",
            };
            await _userManager.CreateAsync(tailor, "rorPO1^_^");
            await _userManager.AddToRoleAsync(tailor, nameof(LavanderRoles.Tailor));


        }


    }
}
