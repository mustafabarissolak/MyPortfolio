using MyPortfolio.Application.Repositories.ContactRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ContactRepositories;

public class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
{
    public ContactWriteRepository(AppDbContext context) : base(context) { }
}
