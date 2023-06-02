using System.Globalization;
using Ardalis.Result;
using CashFlow.Architecture.Core.CashAggregate;
using CashFlow.Architecture.Core.CashAggregate.Enums;
using CashFlow.Architecture.Core.Interfaces;
using CashFlow.Architecture.SharedKernel.CustomExceptions;
using CashFlow.Architecture.SharedKernel.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CashFlow.Architecture.Core.Services;

public class GetCashFlowDayReportService : IGetCashFlowDayReportService
{
    private readonly IRepository<Cash> _repository;
    private readonly ILogger<GetCashFlowDayReportService> _logger;
    private readonly IMemoryCache _cache;

    public GetCashFlowDayReportService(IRepository<Cash> repository,
        ILogger<GetCashFlowDayReportService> logger,
        IMemoryCache cache)
    {
        _repository = repository;
        _logger = logger;
        _cache = cache;
    }

    public CashFlowDayReport Get(DateTime date)
    {
        var amount = (decimal)(_cache.Get(date.Date)??decimal.Zero);
        
        _logger.LogInformation($"Report generated to date {date.ToString(CultureInfo.InvariantCulture)}");
        
        return new Result<CashFlowDayReport>(new CashFlowDayReport(date, amount));
    }
}