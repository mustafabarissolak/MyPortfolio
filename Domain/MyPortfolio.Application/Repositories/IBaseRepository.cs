using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Common;

namespace MyPortfolio.Application.Repositories;

public interface IBaseRepository<T> where T :  BaseEntity
{
    DbSet<T> Table { get; }
}
