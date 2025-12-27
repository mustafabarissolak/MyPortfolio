using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.EducationRepositories;

public class EducationWriteRepository : WriteRepository<Education>, IEducationWriteRepository
{
    public EducationWriteRepository(AppDbContext context) : base(context) { }
}
