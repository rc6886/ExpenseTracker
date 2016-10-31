using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Module = Autofac.Module;

namespace ExpenseTracker.Core.Ioc
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;

        public CoreModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            
            builder.Register<IDbConnectionFactory>(ctx => new OrmLiteConnectionFactory(_connectionString, SqlServer2012Dialect.Provider));
            builder.Register<IDbConnection>(ctx =>
            {
                var dbConnFactory = ctx.Resolve<IDbConnectionFactory>();
                return dbConnFactory.Open();
            });

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}
