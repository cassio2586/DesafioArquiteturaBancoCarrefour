using Clean.Architecture.Core.CashAggregate.Enums;

namespace Clean.Architecture.Web.Endpoints.CashEndpoints;

public class GetCashFlowReportDayResponse
{
  public DateTime Day { get; set; }
  public Decimal Amount { get; set; }
  
  public GetCashFlowReportDayResponse(DateTime day, decimal amount)
  {
    Day = day;
    Amount = amount;
  }
}
