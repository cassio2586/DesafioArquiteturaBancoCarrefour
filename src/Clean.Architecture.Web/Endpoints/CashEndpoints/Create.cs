using Ardalis.Result;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Web.Endpoints.CashEndpoints;
using FastEndpoints;

namespace Clean.Architecture.Web.CashEndpoints;

public class Create : Endpoint<CreateCashRequest, CreateCashResponse>
{
  private readonly ICreateCashService _createCashService;
  public Create(ICreateCashService service)
  {
    _createCashService = service;
  }

  public override void Configure()
  {
    Post(CreateCashRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("CashEndpoints"));
  }
  public override async Task HandleAsync(
    CreateCashRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Description == null)
    {
      ThrowError("Description is required");
    }
    
    var result = await _createCashService.Add(request.Description, request.Amount, request.TransactionType);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    await SendNoContentAsync(cancellationToken);
  }
}
