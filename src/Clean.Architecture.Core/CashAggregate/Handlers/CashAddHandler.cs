using Clean.Architecture.Core.CashAggregate.Events;
using Clean.Architecture.SharedKernel.Interfaces;
using MediatR;

namespace Clean.Architecture.Core.CashAggregate.Handlers;

public class CashAddHandler : INotificationHandler<CashAddEvent>
{
  public CashAddHandler()
  {
  }

  public Task Handle(CashAddEvent domainEvent, CancellationToken cancellationToken)
  {
    return Task.Delay(1);
  }
}
