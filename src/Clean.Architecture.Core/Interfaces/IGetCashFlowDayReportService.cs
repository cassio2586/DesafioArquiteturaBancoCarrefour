using Ardalis.Result;
using Clean.Architecture.Core.CashAggregate;
namespace Clean.Architecture.Core.Interfaces;

public interface IGetCashFlowDayReportService
{
  Task<Result<CashFlowDayReport>> Get(DateTime date);
}
