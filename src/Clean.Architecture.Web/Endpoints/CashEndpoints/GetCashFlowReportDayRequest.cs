using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.CashEndpoints;

public class GetCashFlowReportDayRequest
{
  public const string Route = "/CashFlowReportDay";

  [Required]
  public DateTime Day { get; set; }
  
}
