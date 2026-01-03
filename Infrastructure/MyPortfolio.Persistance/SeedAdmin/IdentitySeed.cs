using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Persistance.SeedAdmin;

public static class IdentitySeed
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        // Admin config bind
        var seedData = new IdentitySeedData
        {
            AdminEmail = configuration["Admin:Email"]!,
            AdminUserName = configuration["Admin:UserName"]!,
            AdminPassword = configuration["Admin:Password"]!
        };

        // Roller
        foreach (var role in Enum.GetNames(typeof(SeedRoles)))
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = role,
                    NormalizedName = role.ToUpper()
                });
            }
        }

        // Admin
        var Admin = await userManager.FindByEmailAsync(seedData.AdminEmail);

        if (Admin == null)
        {
            Admin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = seedData.AdminUserName,
                Email = seedData.AdminEmail,
                EmailConfirmed = false,
            };

            var result = await userManager.CreateAsync(Admin, seedData.AdminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(Admin, SeedRoles.Admin.ToString());
            }
        }
    }
}
