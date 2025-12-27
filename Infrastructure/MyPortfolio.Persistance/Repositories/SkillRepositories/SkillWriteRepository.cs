using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.SkillRepositories;

public class SkillWriteRepository : WriteRepository<Skill>, ISkillWriteRepository
{
    public SkillWriteRepository(AppDbContext context) : base(context)
    {
    }
}
