using MyPortfolio.Application.Repositories.ContactInfoRepositories;
using MyPortfolio.Core.Entities;
using MyPortfolio.Persistance.Context;

namespace MyPortfolio.Persistance.Repositories.ContactInfoRepositories;

public class ContactInfoWriteRepository : WriteRepository<ContactInfo>, IContactInfoWriteRepository
{
    public ContactInfoWriteRepository(AppDbContext context) : base(context) { }
}
