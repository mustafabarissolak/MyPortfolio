using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;
using MyPortfolio.Application.Repositories.ContactRepositories;
using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Application.Repositories.ImageRepositories;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Persistance.Context;
using MyPortfolio.Persistance.Repositories.AboutRepositories;
using MyPortfolio.Persistance.Repositories.ContactInfoRepositories;
using MyPortfolio.Persistance.Repositories.ContactRepositories;
using MyPortfolio.Persistance.Repositories.EducationRepositories;
using MyPortfolio.Persistance.Repositories.ExperienceRepositories;
using MyPortfolio.Persistance.Repositories.SkillRepositories;
using MyPortfolio.Persistance.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Persistance.Repositories.WelcomeAreaRepositories;

namespace MyPortfolio.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection"),
                sql =>
                {
                    sql.MigrationsAssembly("MyPortfolio.Persistance");
                });
        });

        #region DI Repositories
        services.AddScoped<ISkillReadRepository, SkillReadRepository>();
        services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();

        services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();

        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository, ContactWriteRepository>();

        services.AddScoped<IContactInfoReadRepository, ContactInfoReadRepository>();
        services.AddScoped<IContactInfoWriteRepository, ContactInfoWriteRepository>();

        services.AddScoped<IEducationReadRepository, EducationReadRepository>();
        services.AddScoped<IEducationWriteRepository, EducationWriteRepository>();

        services.AddScoped<IExperienceReadRepository, ExperienceReadRepository>();
        services.AddScoped<IExperienceWriteRepository, ExperienceWriteRepository>();

        services.AddScoped<IImageReadRepository, ImageReadRepository>();
        services.AddScoped<IImageWriteRepository, ImageWriteRepository>();

        services.AddScoped<ISocialMediaAccountReadRepository, SocialMediaAccountReadRepository>();
        services.AddScoped<ISocialMediaAccountWriteRepository, SocialMediaAccountWriteRepository>();

        services.AddScoped<IWelcomeAreaReadRepository, WelcomeAreaReadRepository>();
        services.AddScoped<IWelcomeAreaWriteRepository, WelcomeAreaWriteRepository>();
        #endregion
    }
}

#region dotnet ef migrations add
/*
 
dotnet ef migrations add mig1 --startup-project ..\..\Presentation\MyPortfolio.MVC

dotnet ef database update --startup-project ..\..\Presentation\MyPortfolio.MVC

*/
#endregion