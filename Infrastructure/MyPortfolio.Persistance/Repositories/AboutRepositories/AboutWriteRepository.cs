using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.AboutRepositories;

public class AboutWriteRepository : WriteRepository<About>, IAboutWriteRepository
{
    public AboutWriteRepository(AppDbContext context) : base(context) { }
}
