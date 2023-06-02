using Ardalis.Specification.EntityFrameworkCore;
using CashFlow.Architecture.SharedKernel.Interfaces;

namespace CashFlow.Architecture.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
