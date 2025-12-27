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

        // SuperAdmin config bind
        var seedData = new IdentitySeedData
        {
            SuperAdminEmail = configuration["SuperAdmin:Email"]!,
            SuperAdminUserName = configuration["SuperAdmin:UserName"]!,
            SuperAdminPassword = configuration["SuperAdmin:Password"]!
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

        // SuperAdmin
        var superAdmin = await userManager.FindByEmailAsync(seedData.SuperAdminEmail);

        if (superAdmin == null)
        {
            superAdmin = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = seedData.SuperAdminUserName,
                Email = seedData.SuperAdminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(superAdmin, seedData.SuperAdminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdmin, SeedRoles.SuperAdmin.ToString());
            }
        }
    }
}
