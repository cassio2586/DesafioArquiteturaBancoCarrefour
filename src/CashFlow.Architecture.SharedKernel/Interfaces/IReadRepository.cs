using Ardalis.Specification;

namespace CashFlow.Architecture.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
