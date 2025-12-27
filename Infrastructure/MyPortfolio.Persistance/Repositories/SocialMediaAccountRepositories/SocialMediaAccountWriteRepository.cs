using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.SocialMediaAccountRepositories;

public class SocialMediaAccountWriteRepository : WriteRepository<SocialMediaAccount>, ISocialMediaAccountWriteRepository
{
    public SocialMediaAccountWriteRepository(AppDbContext context) : base(context) { }
}
