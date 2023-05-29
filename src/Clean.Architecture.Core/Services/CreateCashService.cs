using Ardalis.Result;
using Clean.Architecture.Core.CashAggregate;
using Clean.Architecture.Core.CashAggregate.Enums;
using Clean.Architecture.Core.CashAggregate.Events;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.ContributorAggregate.Events;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.SharedKernel.Interfaces;
using MediatR;

namespace Clean.Architecture.Core.Services;

public class CreateCashService : ICreateCashService
{
  private readonly IRepository<Cash> _repository;
  private readonly IMediator _mediator;

  public CreateCashService(IRepository<Cash> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeleteContributor(int contributorId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ContributorDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }

  public async Task<Result> Add(string description, decimal amount, TransactionTypeEnum transactionType)
  {
    var cashAggregate = new Cash(description, amount, transactionType);
    
    var cashAdded = await _repository.AddAsync(cashAggregate);
    var domainEvent = new CashAddEvent(cashAdded.Id);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
