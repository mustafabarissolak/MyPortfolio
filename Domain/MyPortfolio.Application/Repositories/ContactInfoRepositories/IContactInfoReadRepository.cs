using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Repositories.ContactInfoRepositories;

public interface IContactInfoReadRepository : IReadRepository<ContactInfo> 
{
    Task<ContactInfo> GetSingleAsync();
}
