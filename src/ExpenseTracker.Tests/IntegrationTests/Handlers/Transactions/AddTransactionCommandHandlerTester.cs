using System;
using ExpenseTracker.Core.Common.Command.Transactions;
using ExpenseTracker.Core.DataAccess.Models;
using NUnit.Framework;
using ServiceStack.OrmLite;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Transactions
{
    [TestFixture]
    public class AddTransactionCommandHandlerTester : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Cleanup();
        }

        [TearDown]
        public void TearDown()
        {
            Cleanup();
        }

        [Test]
        public void Should_add_transaction()
        {
            var vendorId = InsertVendor();

            var command = new AddTransactionCommand
            {
                VendorName = "Vendor",
                TransactionType = 1,
                Amount = 123.22M,
                Description = "This is a description.",
            };

            Mediator.Send(command);

            var transaction = Db.Single<Core.DataAccess.Models.Transactions>("SELECT TOP 1 * FROM dbo.Transactions;");

            transaction.VendorId.ShouldBe(vendorId);
            transaction.TransactionTypeId.ShouldBe(command.TransactionType);
            transaction.Description.ShouldBe(command.Description);
            transaction.Amount.ShouldBe(command.Amount);
        }

        private void Cleanup()
        {
            Db.ExecuteNonQuery("DELETE FROM dbo.Transactions;");
            Db.ExecuteNonQuery("DELETE FROM dbo.Vendor;");
        }

        private int InsertVendor()
        {
            return (int)Db.Insert(new Vendor
            {
                Name = "Vendor",
                DateCreated = DateTime.Now,
                DateModified = null
            }, true);
        }
    }
}