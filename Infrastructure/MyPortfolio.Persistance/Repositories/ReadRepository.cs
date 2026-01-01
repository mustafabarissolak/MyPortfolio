using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.Repositories;
using MyPortfolio.Core.Common;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll() => Table.AsQueryable();

    public virtual async Task<T> GetByIdAsync(string id) => (await (Table.AsQueryable()).FirstOrDefaultAsync(e => e.Id == id))!;
}
