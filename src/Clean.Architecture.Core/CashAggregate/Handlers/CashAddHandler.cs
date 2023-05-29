using Clean.Architecture.Core.CashAggregate.Events;
using Clean.Architecture.SharedKernel.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.CashAggregate.Handlers;

public class CashAddHandler : INotificationHandler<CashAddEvent>
{
  private readonly ILogger<CashAddHandler> _logger;
  public CashAddHandler(ILogger<CashAddHandler> logger)
  {
    _logger = logger;
  }

  public Task Handle(CashAddEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Raised Event CashAddEvent");
    return Task.Delay(1);
  }
}
