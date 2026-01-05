using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Application.Services;
using MyPortfolio.Application.Storages;
using MyPortfolio.Core.Entities;
using MyPortfolio.Infrastructure.IdentitySettings;
using MyPortfolio.Infrastructure.Services;
using MyPortfolio.Infrastructure.SmtpServices;
using MyPortfolio.Infrastructure.Storages;
using MyPortfolio.Infrastructure.Storages.Local;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            // sifre kurallari
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.AllowedForNewUsers = true; // yeni kullanıcılar icin de hesap kilitleme aktif olsun mu?

            // db'de benzersiz email
            options.User.RequireUniqueEmail = true;

        }).AddErrorDescriber<TurkishIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddScoped<IStorageService, StorageService>();
        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 1L * 1024 * 1024 * 1024; // 1GB
        });

        services.Configure<SmtpSettings>(configuration.GetSection("Smtp"));
        services.AddTransient<IMailTemplateService, MailTemplateService>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
    }

    public static void AddStorage(this IServiceCollection services, StorageTypes type)
    {
        switch (type)
        {
            case StorageTypes.Local:
                services.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}
