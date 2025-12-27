using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ExperienceRepositories;

public class ExperienceReadRepository: ReadRepository<Experience>, IExperienceReadRepository
{
    public ExperienceReadRepository(AppDbContext context) : base(context) { }
}
