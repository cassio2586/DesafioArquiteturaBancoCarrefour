using Ardalis.GuardClauses;
using CashFlow.Architecture.Core.CashAggregate.Enums;
using CashFlow.Architecture.SharedKernel;
using CashFlow.Architecture.SharedKernel.Interfaces;

namespace CashFlow.Architecture.Core.CashAggregate;

public class Cash : EntityBase, IAggregateRoot
{
  public string Description { get; private set; }
  public decimal Amount { get; set; }
  public TransactionTypeEnum TransactionType { get; private set; }
  public DateTime DateTimeTransaction { get; set; }
  public Cash(string description, decimal amount, TransactionTypeEnum transactionType, DateTime dateTimeTransaction)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
    Amount = Guard.Against.NegativeOrZero(amount, nameof(amount));
    TransactionType = transactionType;
    DateTimeTransaction = dateTimeTransaction;
  }
}
