using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.Repositories;
using MyPortfolio.Core.Common;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    readonly AppDbContext _context;
    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();
    public async Task AddAsync(T entity) => await Table.AddAsync(entity);
    public void Update(T entity) => Table.Update(entity);

    public void Remove(T entity) => Table.Remove(entity);

    public async Task RemoveByIdAsync(string id) => Table.Remove((await Table.FirstOrDefaultAsync(e => e.Id == id))!);

    public void RemoveRange(List<T> entities) => Table.RemoveRange(entities);

    public async Task SaveAsync() => await _context.SaveChangesAsync();

}
