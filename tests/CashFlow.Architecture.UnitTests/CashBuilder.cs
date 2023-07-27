using CashFlow.Architecture.Core.CashAggregate;
using CashFlow.Architecture.Core.CashAggregate.Enums;


namespace Clean.Architecture.UnitTests;

public class CashBuilder
{
  private Cash _cash = new Cash("unitteste",10,transactionType: TransactionTypeEnum.Credit, DateTime.Now);

  public CashBuilder Id(int id)
  {
    _cash.Id = id;
    return this;
  }

  public CashBuilder Amount(decimal amount)
  {
    _cash.Amount = amount;
    return this;
  }

  public CashBuilder Description(string description)
  {
    _cash.Description = description;
    return this;
  }

  public CashBuilder WithDefaultValues()
  {
    _cash = new Cash("Test Item") {Id = 1, Description = "Test Item", Amount = 10, DateTimeTransaction = DateTime.Now};

    return this;
  }

  public Cash Build() => _cash;
}
