using Clean.Architecture.Core.CashAggregate.Enums;

namespace Clean.Architecture.Web.Endpoints.CashEndpoints;

public class CreateCashResponse
{
  public CreateCashResponse(string description, decimal amount, TransactionTypeEnum transactionType)
  {
    Description = description;
    Amount = amount;
    TransactionType = transactionType;
  }
  public string Description { get; set; }
  public decimal Amount { get; set; }
  public TransactionTypeEnum? TransactionType { get; set; }
}
