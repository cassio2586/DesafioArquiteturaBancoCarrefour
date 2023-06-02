using Autofac;
using CashFlow.Architecture.Core.Interfaces;
using CashFlow.Architecture.Core.Services;

namespace CashFlow.Architecture.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
      builder.RegisterType<CreateCashService>()
        .As<ICreateCashService>().InstancePerLifetimeScope();
      
      builder.RegisterType<GetCashFlowDayReportService>()
          .As<IGetCashFlowDayReportService>().InstancePerLifetimeScope();
  }
}
