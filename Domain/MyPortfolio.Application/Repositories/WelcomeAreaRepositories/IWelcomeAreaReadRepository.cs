using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Repositories.WelcomeAreaRepositories;

public interface IWelcomeAreaReadRepository : IReadRepository<WelcomeArea>
{
    Task<WelcomeArea> GetSingleAsync();
}
