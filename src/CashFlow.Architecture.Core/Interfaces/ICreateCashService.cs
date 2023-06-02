using Ardalis.Result;
using CashFlow.Architecture.Core.CashAggregate.Enums;

namespace CashFlow.Architecture.Core.Interfaces;

public interface ICreateCashService
{
  public Task<Result> Add(string description, decimal amount, TransactionTypeEnum transactionType, DateTime dateTimeTransaction);
}
