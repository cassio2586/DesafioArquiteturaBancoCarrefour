using Ardalis.ApiEndpoints;
using CashFlow.Architecture.Web.Endpoints.CashEndpoints;
using CashFlow.Architecture.Core.Interfaces;
using CashFlow.Architecture.SharedKernel.CustomExceptions;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace CashFlow.Architecture.Web.CashEndpoints;

[Authorize]
public class GetCashFlowReportDay : Endpoint<GetCashFlowReportDayRequest, GetCashFlowReportDayResponse>
{
    private readonly IGetCashFlowDayReportService _getCashFlowDayReportService;
    private readonly ILogger<GetCashFlowReportDay> _logger;

    public GetCashFlowReportDay(IGetCashFlowDayReportService flowDayReportService, ILogger<GetCashFlowReportDay> logger)
    {
        _getCashFlowDayReportService = flowDayReportService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get(GetCashFlowReportDayRequest.Route);
        
        Options(x => x
            .WithTags("CashEndpoints"));
    }

    public override async Task HandleAsync(GetCashFlowReportDayRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result =  _getCashFlowDayReportService.Get(request.Day);
            
            await SendAsync(new GetCashFlowReportDayResponse(result.Day, result.Amount),
                cancellation: cancellationToken);
        }
        catch (NoDataReportException)
        {
            _logger.LogCritical("Invalid Date Parameter");
            await SendNoContentAsync(cancellationToken);
        }
        catch (InvalidDataException)
        {
            await SendErrorsAsync(400,cancellationToken);
        }
    }
}