using Microsoft.AspNetCore.Identity;

namespace MyPortfolio.MVC;

public static class AuthenticationServiceRegistration
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Dashboard/Auth/Login";
            options.LogoutPath = "/Dashboard/Auth/Logout";

            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
        {
            opt.TokenLifespan = TimeSpan.FromMinutes(15);
        });

        return services;
    }
}
