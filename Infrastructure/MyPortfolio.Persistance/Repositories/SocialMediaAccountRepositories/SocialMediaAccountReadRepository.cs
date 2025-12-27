using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.SocialMediaAccountRepositories;

public class SocialMediaAccountReadRepository : ReadRepository<SocialMediaAccount>, ISocialMediaAccountReadRepository
{
    public SocialMediaAccountReadRepository(AppDbContext context) : base(context) { }
}
