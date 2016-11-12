using System;
using System.Linq;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.DataAccess.Models;
using NUnit.Framework;
using ServiceStack.OrmLite;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Dashboard
{
    [TestFixture]
    public class GetDashboardTransactionsQueryHandlerTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            DeleteData();
            SeedData();
        }

        [TearDown]
        public void TearDown()
        {
            DeleteData();
        }

        [Test]
        public void Should_get_transactions()
        {
            var query = new GetDashboardTransactionsQuery();
            var result = Mediator.Send(query);

            result.Transactions.Count().ShouldBe(1);

            result.Transactions.ElementAt(0).Amount.ShouldBe(10);
            result.Transactions.ElementAt(0).TransactionType.ShouldBe("Income");
            result.Transactions.ElementAt(0).TransactionDate.ShouldBe(new DateTime(2015, 1, 1));
            result.Transactions.ElementAt(0).Vendor.ShouldBe("New Vendor");
        }

        private void SeedData()
        {
            var vendor = new Vendor
            {
                Name = "New Vendor",
                DateCreated = new DateTime(2015, 1, 1)
            };

            var vendorId = (int)Db.Insert(vendor, true);

            var transaction = new Core.DataAccess.Models.Transactions
            {
                Amount = 10,
                DateCreated = new DateTime(2015, 1, 1),
                DateModified = new DateTime(2015, 1, 3),
                Description = "This is an entry.",
                Id = 100,
                TransactionTypeId = 1,
                VendorId = vendorId,
            };

            Db.Insert(transaction);
        }

        private void DeleteData()
        {
            Db.DeleteAll<Core.DataAccess.Models.Transactions>();
            Db.DeleteAll<Vendor>();
        }
    }
}