using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.CashAggregate;

public class CashFlowDayReport : ValueObject, IAggregateRoot
{
  public DateTime Day { get; private set; }
  public decimal Amount { get; private set; }

  public CashFlowDayReport(DateTime day, decimal amount)
  {
    Day = day;
    Amount = amount;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    throw new NotImplementedException();
  }
}
