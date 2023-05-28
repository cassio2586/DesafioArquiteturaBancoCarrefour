using Ardalis.GuardClauses;
using Clean.Architecture.Core.CashAggregate.Enums;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

namespace Clean.Architecture.Core.CashAggregate;

public class Cash : EntityBase, IAggregateRoot
{
  public string Description { get; private set; }
  public decimal Amount { get; private set; }
  public TransactionTypeEnum TransactionType { get; private set; }

  public Cash(string description, decimal amount, TransactionTypeEnum transactionType)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
    Amount = Guard.Against.NegativeOrZero(amount, nameof(amount));
    TransactionType = transactionType;
  }
 /*
  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }*/
}
