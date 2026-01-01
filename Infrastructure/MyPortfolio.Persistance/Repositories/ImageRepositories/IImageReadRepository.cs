using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;
using MyPortfolio.Persistance.Repositories;

namespace MyPortfolio.Application.Repositories.ImageRepositories;

public class ImageReadRepository : ReadRepository<Image>, IImageReadRepository
{
    public ImageReadRepository(AppDbContext context) : base(context) { }
}