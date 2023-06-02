using Ardalis.Specification;

namespace CashFlow.Architecture.SharedKernel.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
