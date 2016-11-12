using System.Data;
using Autofac;
using ExpenseTracker.Core.Ioc;
using MediatR;
using NUnit.Framework;

namespace ExpenseTracker.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IContainer Container;
        protected IMediator Mediator;
        protected IDbConnection Db;

        [OneTimeSetUp]
        public void BaseSetup()
        {
            var builder = new ContainerBuilder();
            // Tests aren't using the database so this is empty for now.
            builder.RegisterModule(new CoreModule("server=.;database=ExpenseTracker;integrated security=true;"));
            Container = builder.Build();

            Mediator = Container.Resolve<IMediator>();
            Db = Container.Resolve<IDbConnection>();
        }
    }
}