using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ExperienceRepositories;

public class ExperienceWriteRepository : WriteRepository<Experience>, IExperienceWriteRepository
{
    public ExperienceWriteRepository(AppDbContext context) : base(context) { }
}
