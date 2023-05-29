using Ardalis.ApiEndpoints;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Web.Endpoints.CashEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.CashEndpoints;

public class GetCashFlowReportDay : EndpointBaseAsync
  .WithRequest<GetCashFlowReportDayRequest>
  .WithActionResult<GetCashFlowReportDayResponse>
{
  private readonly IGetCashFlowDayReportService _getCashFlowDayReportServiceService;
  public GetCashFlowReportDay(IGetCashFlowDayReportService flowDayReportServiceService)
  {
    _getCashFlowDayReportServiceService = flowDayReportServiceService;
  }
  
  [HttpGet(GetCashFlowReportDayRequest.Route)]
  public override async Task<ActionResult<GetCashFlowReportDayResponse>> HandleAsync([FromRoute] GetCashFlowReportDayRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var result = await _getCashFlowDayReportServiceService.Get(request.Day);
    
    return Ok(new GetCashFlowReportDayResponse(result.Value.Day,result.Value.Amount));
  }
}
