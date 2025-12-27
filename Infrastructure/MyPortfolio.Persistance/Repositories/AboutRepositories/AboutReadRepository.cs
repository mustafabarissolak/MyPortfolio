using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.AboutRepositories;

public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
{
    public AboutReadRepository(AppDbContext context) : base(context) { }
}
