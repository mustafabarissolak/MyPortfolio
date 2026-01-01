using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.AboutRepositories;

public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
{
    private readonly AppDbContext _context;
    public AboutReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<About> GetSingleAsync()
        => (await _context.Abouts.Include(x => x.Image).AsNoTracking().FirstOrDefaultAsync())!;
    public override async Task<About> GetByIdAsync(string id)
        => (await _context.Abouts.Include(x => x.Image).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id))!;
}
