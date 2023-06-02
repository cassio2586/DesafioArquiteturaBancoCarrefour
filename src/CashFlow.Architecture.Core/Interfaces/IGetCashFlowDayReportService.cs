using Ardalis.Result;
using CashFlow.Architecture.Core.CashAggregate;

namespace CashFlow.Architecture.Core.Interfaces;

public interface IGetCashFlowDayReportService
{
  CashFlowDayReport Get(DateTime date);
}
