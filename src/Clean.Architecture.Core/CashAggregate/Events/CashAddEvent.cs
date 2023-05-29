using Clean.Architecture.SharedKernel;

namespace Clean.Architecture.Core.CashAggregate.Events;

public class CashAddEvent : DomainEventBase
{
    public int CashId { get; set; }

    public CashAddEvent(int cashId)
    {
        CashId = cashId;
    }
}