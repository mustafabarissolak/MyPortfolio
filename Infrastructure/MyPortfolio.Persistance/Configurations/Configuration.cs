using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyPortfolio.Persistance.Configurations;

static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            var configurationManager = new ConfigurationManager();

            configurationManager
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return configurationManager.GetConnectionString("SqlServerConnection")!;
        }
    }
}
