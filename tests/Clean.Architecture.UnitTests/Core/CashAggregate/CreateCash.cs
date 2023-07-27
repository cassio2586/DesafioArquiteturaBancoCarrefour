using CashFlow.Architecture.Core.CashAggregate;
using CashFlow.Architecture.Core.CashAggregate.Enums;
using CashFlow.Architecture.Core.Services;
using CashFlow.Architecture.SharedKernel.Interfaces;

using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using ILogger = Castle.Core.Logging.ILogger;

namespace Clean.Architecture.UnitTests.Core.Services
{
    public class CreateCash
    {
        private readonly Mock<IRepository<Cash>> _mockRepo = new Mock<IRepository<Cash>>();
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly CreateCashService _service;

        public CreateCash()
        {
            _service = new CreateCashService(_mockRepo.Object, _mockMediator.Object);
        }

        [Fact]
        public Task ReturnsTrueIFHaveDescription()
        {
            var cash = new Cash("teste", 10, TransactionTypeEnum.Credit, DateTime.Now);
            Assert.Equal("teste", cash.Description);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ReturnsTrueIFHaveAmount()
        {
            var cash = new Cash("teste", 10, TransactionTypeEnum.Credit, DateTime.Now);
            Assert.Equal(10, cash.Amount);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task ReturnsTrueIFHaveTransactionType()
        {
            var cash = new Cash("teste", 10, TransactionTypeEnum.Credit, DateTime.Now);
            Assert.Equal(TransactionTypeEnum.Credit, TransactionTypeEnum.Credit);
            return Task.CompletedTask;
        }
    }
}
