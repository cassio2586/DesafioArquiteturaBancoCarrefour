using CashFlow.Architecture.Core.CashAggregate.Enums;
using CashFlow.Architecture.SharedKernel;

namespace CashFlow.Architecture.Core.CashAggregate.Events;

public class CashAddEvent : DomainEventBase
{
    public int CashId { get; set; }
    public decimal Amount { get; set; }

    public TransactionTypeEnum TransactionType;
    public DateTime DateTimeTransaction { get; set; }

    public CashAddEvent(int cashId, decimal amount, TransactionTypeEnum transactionType, DateTime dateTimeTransaction)
    {
        CashId = cashId;
        Amount = amount;
        TransactionType = transactionType;
        DateTimeTransaction = dateTimeTransaction;
    }
}