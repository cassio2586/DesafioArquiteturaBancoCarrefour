using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.SharedKernel.CustomExceptions;
using Clean.Architecture.Web.Endpoints.CashEndpoints;
using FastEndpoints;

namespace Clean.Architecture.Web.CashEndpoints;

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
        AllowAnonymous();
        Options(x => x
            .WithTags("CashEndpoints"));
    }

    public override async Task HandleAsync(GetCashFlowReportDayRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _getCashFlowDayReportService.Get(request.Day);
            
            await SendAsync(new GetCashFlowReportDayResponse(result.Value.Day, result.Value.Amount),
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