using Autofac;
using Autofac.Integration.Mvc;
using ExamFereshteh.Models;
using ExamFereshteh.Services.Factory;
using ExamFereshteh.Services.Repository;

namespace ExamFereshteh.AutoFac
{
    public class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<GetRatesList>().As<IGateRatesList>();
            builder.RegisterType<GetTransactionsList>().As<IGetTransactionsList>();
            builder.RegisterType<FakeRepository<Rate>>().As<IRepository<Rate>>();
            builder.RegisterType<FakeRepository<Transaction>>().As<IRepository<Transaction>>();
            return builder.Build();

        }
    }
}