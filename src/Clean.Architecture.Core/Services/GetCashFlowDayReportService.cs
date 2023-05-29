using System.Globalization;
using Ardalis.Result;
using Clean.Architecture.Core.CashAggregate;
using Clean.Architecture.Core.CashAggregate.Enums;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.SharedKernel.CustomExceptions;
using Clean.Architecture.SharedKernel.Interfaces;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.Services;

public class GetCashFlowDayReportService : IGetCashFlowDayReportService
{
    private readonly IRepository<Cash> _repository;
    private readonly ILogger<GetCashFlowDayReportService> _logger;

    public GetCashFlowDayReportService(IRepository<Cash> repository,
        ILogger<GetCashFlowDayReportService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<CashFlowDayReport>> Get(DateTime date)
    {
        List<Cash> items = await _repository.ListAsync();
        if (!items.Any(x=>x.DateTimeTransaction.Day.Equals(date.Day) && x.DateTimeTransaction.Month.Equals(date.Month) && x.DateTimeTransaction.Year.Equals(date.Year)))
        {
            _logger.LogInformation($"No data to Report on day {date.ToString(CultureInfo.InvariantCulture)}");
            throw new NoDataReportException();
        }

        foreach (var item in items)
        {
            if (item.TransactionType.Equals(TransactionTypeEnum.Debit))
                item.Amount = item.Amount *-1;
        }
        var amount = items.Where(x =>
            x.DateTimeTransaction.Day.Equals(date.Day) && x.DateTimeTransaction.Month.Equals(date.Month) &&
            x.DateTimeTransaction.Year.Equals(date.Year)).Sum(x => x.Amount);
        
        _logger.LogInformation($"Report generated to day {date.ToString(CultureInfo.InvariantCulture)}");

        return new Result<CashFlowDayReport>(new CashFlowDayReport(date, amount));
    }
}