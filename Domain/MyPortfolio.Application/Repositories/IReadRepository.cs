using MyPortfolio.Core.Common;

namespace MyPortfolio.Application.Repositories;

public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task<T>  GetByIdAsync(string id);
}
