using Clean.Architecture.Core.CashAggregate;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.Endpoints.CashEndpoints;
using Clean.Architecture.Web.Endpoints.ContributorEndpoints;
using FastEndpoints;

namespace Clean.Architecture.Web.CashEndpoints;

public class Create : Endpoint<CreateCashRequest, CreateCashResponse>
{
  private readonly IRepository<Cash> _repository;

  public Create(IRepository<Cash> repository)
  {
    _repository = repository;
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
    if (request.Amount == null)
    {
      ThrowError("Amount is required");
    }
    
    if (request.TransactionType is null)
    {
      ThrowError("TransactionType is required");
    }
    

    var newCash = new Cash(request.Description, request.Amount??0,request.TransactionType??0);
    var createdItem = await _repository.AddAsync(newCash, cancellationToken);
    var response = new CreateCashResponse
    (
      description: createdItem.Description,
      amount: createdItem.Amount,
      transactionType:createdItem.TransactionType
    );

    await SendAsync(response, cancellation: cancellationToken);
  }
}
