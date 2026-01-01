using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.WelcomeAreaRepositories;

public class WelcomeAreaReadRepository : ReadRepository<WelcomeArea>, IWelcomeAreaReadRepository
{
    private readonly AppDbContext _context;
    public WelcomeAreaReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<WelcomeArea> GetSingleAsync()
        => (await _context.WelcomeAreas.Include(x => x.Image).AsNoTracking().FirstOrDefaultAsync())!;
    public override async Task<WelcomeArea> GetByIdAsync(string id)
        => (await _context.WelcomeAreas.Include(x => x.Image).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id))!;

}
