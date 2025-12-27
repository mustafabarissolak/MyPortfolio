using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.EducationRepositories;

public class EducationReadRepository : ReadRepository<Education>, IEducationReadRepository
{
    public EducationReadRepository(AppDbContext context) : base(context) { }
}
