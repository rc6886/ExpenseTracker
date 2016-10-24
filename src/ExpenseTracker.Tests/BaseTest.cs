using Autofac;
using ExpenseTracker.Core.Ioc;
using MediatR;
using NUnit.Framework;

namespace ExpenseTracker.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IMediator Mediator;

        [OneTimeSetUp]
        public void BaseSetup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreModule());
            var container = builder.Build();

            Mediator = container.Resolve<IMediator>();
        }
    }
}