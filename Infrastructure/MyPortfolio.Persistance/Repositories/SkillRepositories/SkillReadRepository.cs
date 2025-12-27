using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.SkillRepositories;

public class SkillReadRepository : ReadRepository<Skill>, ISkillReadRepository
{
    public SkillReadRepository(AppDbContext context) : base(context)
    {
    }
}
