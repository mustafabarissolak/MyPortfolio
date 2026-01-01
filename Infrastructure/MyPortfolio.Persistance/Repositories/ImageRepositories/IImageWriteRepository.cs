using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;
using MyPortfolio.Persistance.Repositories;

namespace MyPortfolio.Application.Repositories.ImageRepositories;

public class ImageWriteRepository : WriteRepository<Image>, IImageWriteRepository
{
    public ImageWriteRepository(AppDbContext context) : base(context) { }
}