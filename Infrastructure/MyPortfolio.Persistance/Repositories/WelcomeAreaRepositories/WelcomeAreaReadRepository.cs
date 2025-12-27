using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.WelcomeAreaRepositories;

public class WelcomeAreaReadRepository : ReadRepository<WelcomeArea>, IWelcomeAreaReadRepository
{
    public WelcomeAreaReadRepository(AppDbContext context) : base(context) { }
}
