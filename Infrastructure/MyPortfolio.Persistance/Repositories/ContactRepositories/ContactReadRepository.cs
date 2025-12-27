using MyPortfolio.Application.Repositories.ContactRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ContactRepositories;

public class ContactReadRepository : ReadRepository<Contact>, IContactReadRepository
{
    public ContactReadRepository(AppDbContext context) : base(context) { }
}
