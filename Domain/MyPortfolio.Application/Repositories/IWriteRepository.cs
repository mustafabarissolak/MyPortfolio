using MyPortfolio.Core.Common;

namespace MyPortfolio.Application.Repositories;

public interface IWriteRepository<T> : IBaseRepository<T> where T :  BaseEntity
{
    Task AddAsync(T entity);
    Task SaveAsync();
    Task RemoveById(string id);
    void Update(T entity);
    void RemoveRange(List<T> entities);
    void Remove(T entity);
}
