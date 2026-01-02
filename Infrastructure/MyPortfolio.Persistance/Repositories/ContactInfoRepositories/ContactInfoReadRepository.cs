using Microsoft.EntityFrameworkCore;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ContactInfoRepositories;

public class ContactInfoReadRepository : ReadRepository<ContactInfo>, IContactInfoReadRepository
{
    private readonly AppDbContext _context;
    public ContactInfoReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ContactInfo> GetSingleAsync()
        => (await _context.ContactInfos.AsNoTracking().FirstOrDefaultAsync())!;
}
