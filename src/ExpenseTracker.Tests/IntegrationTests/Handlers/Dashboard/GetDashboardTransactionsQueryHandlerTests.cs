using System;
using System.Linq;
using ExpenseTracker.Core.Common.Query.Dashboard;
using NUnit.Framework;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Dashboard
{
    [TestFixture]
    public class GetDashboardTransactionsQueryHandlerTests : BaseTest
    {
        [Test]
        public void Should_get_transactions()
        {
            var query = new GetDashboardTransactionsQuery();
            var result = Mediator.Send(query);

            result.Transactions.Count().ShouldBe(3);

            result.Transactions.ElementAt(0).Amount.ShouldBe(25.35M);
            result.Transactions.ElementAt(0).Name.ShouldBe("Test1");
            result.Transactions.ElementAt(0).TransactionDate.ShouldBe(new DateTime(2016, 1, 1));
            result.Transactions.ElementAt(0).TransactionType.ShouldBe("Income");

            result.Transactions.ElementAt(0).Amount.ShouldBe(25.35M);
            result.Transactions.ElementAt(0).Name.ShouldBe("Test1");
            result.Transactions.ElementAt(0).TransactionDate.ShouldBe(new DateTime(2016, 1, 1));
            result.Transactions.ElementAt(0).TransactionType.ShouldBe("Income");

            result.Transactions.ElementAt(0).Amount.ShouldBe(25.35M);
            result.Transactions.ElementAt(0).Name.ShouldBe("Test1");
            result.Transactions.ElementAt(0).TransactionDate.ShouldBe(new DateTime(2016, 1, 1));
            result.Transactions.ElementAt(0).TransactionType.ShouldBe("Income");
        }
    }
}