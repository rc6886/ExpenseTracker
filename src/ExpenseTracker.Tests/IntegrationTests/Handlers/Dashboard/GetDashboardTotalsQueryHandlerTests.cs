using System;
using System.Collections.Generic;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.DataAccess.Models;
using ExpenseTracker.Core.Features.Dashboard;
using ExpenseTracker.Core.Infrastructure.Services;
using NUnit.Framework;
using ServiceStack.OrmLite;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Dashboard
{
    [TestFixture]
    public class GetDashboardTotalsQueryHandlerTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Db.DeleteAll<Core.DataAccess.Models.Transactions>();
            Db.DeleteAll<Vendor>();

            SeedTestData();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Db.DeleteAll<Core.DataAccess.Models.Transactions>();
            Db.DeleteAll<Vendor>();
        }

        [Test]
        public void Should_get_correct_totals()
        {
            var query = new GetDashboardTotalsQuery();
            var handler = new GetDashboardTotalsQueryHandler(Db, new FakeSystemTime());
            var result = handler.Handle(query);

            result.TotalSpentToday.ShouldBe(25M);
            result.TotalSpentThisWeek.ShouldBe(105M);
            result.TotalSpentThisMonth.ShouldBe(105M);
            result.TotalIncomeThisMonth.ShouldBe(1000M);
        }

        private void SeedTestData()
        {
            var vendorId = (int) Db.Insert(new Vendor
            {
                Name = "Test Vendor",
                DateCreated = DateTime.Now,
            }, true);

            var transactions = new List<Core.DataAccess.Models.Transactions>
            {
                new Core.DataAccess.Models.Transactions
                {
                    VendorId = vendorId,
                    Amount = 25,
                    DateCreated = new DateTime(2016, 1, 4),
                    TransactionTypeId = 2,
                },
                new Core.DataAccess.Models.Transactions
                {
                    VendorId = vendorId,
                    Amount = 35,
                    DateCreated = new DateTime(2016, 1, 5),
                    TransactionTypeId = 2,
                },
                new Core.DataAccess.Models.Transactions
                {
                    VendorId = vendorId,
                    Amount = 45,
                    DateCreated = new DateTime(2016, 1, 6),
                    TransactionTypeId = 2,
                },
                new Core.DataAccess.Models.Transactions
                {
                    VendorId = vendorId,
                    Amount = 1000,
                    DateCreated = new DateTime(2016, 1, 7),
                    TransactionTypeId = 1,
                },
            };

            Db.InsertAll(transactions);
        }
    }

    public class FakeSystemTime : ISystemTime
    {
        public DateTime Now => new DateTime(2016, 1, 4);
    }
}

