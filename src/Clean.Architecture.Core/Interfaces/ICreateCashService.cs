using Ardalis.Result;
using Clean.Architecture.Core.CashAggregate.Enums;

namespace Clean.Architecture.Core.Interfaces;

public interface ICreateCashService
{
  public Task<Result> Add(string description, decimal amount, TransactionTypeEnum transactionTyoe);
}
