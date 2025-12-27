using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.WelcomeAreaRepositories;

public class WelcomeAreaWriteRepository : WriteRepository<WelcomeArea>, IWelcomeAreaWriteRepository
{
    public WelcomeAreaWriteRepository(AppDbContext context) : base(context) { }
}