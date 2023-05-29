using Ardalis.Result;
using Clean.Architecture.Core.CashAggregate;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.Services;

public class GetCashFlowDayReportServiceService : IGetCashFlowDayReportService
{
  private readonly IRepository<Cash> _repository;

  public GetCashFlowDayReportServiceService(IRepository<Cash> repository)
  {
    _repository = repository;
  }
  
  public async Task<Result<CashFlowDayReport>> Get(DateTime day)
  {
    List<Cash> items = await _repository.ListAsync();
    var amount = items.Where(x=>x.DateTimeTransaction.Day.Equals(day.Day)).Sum(x => x.Amount);

    return new Result<CashFlowDayReport>(new CashFlowDayReport(day,amount));
  }
}