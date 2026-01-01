using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Application.Storages;
using MyPortfolio.Infrastructure.Storages;
using MyPortfolio.Infrastructure.Storages.Local;

namespace MyPortfolio.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 1L * 1024 * 1024 * 1024; // 1GB
        });
    }

    public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
    }

    public static void AddStorage(this IServiceCollection services, StorageTypes type)
    {
        switch(type)
        {
            case StorageTypes.Local:
                services.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}
