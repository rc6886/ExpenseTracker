using System;
using ExpenseTracker.Core.Common.Command.Transactions;
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
            var transactionTypeId = InsertTransactionType();
            var transactionId = Guid.NewGuid();

            var command = new AddTransactionCommand
            {
                Id = transactionId,
                VendorId = vendorId,
                TransactionTypeId = transactionTypeId,
                Amount = 123.22M,
                Description = "This is a description.",
            };

            Mediator.Send(command);

            var transaction = Db.Single<Core.DataAccess.Models.Transactions>(x => x.Id == command.Id);

            transaction.VendorId.ShouldBe(command.VendorId);
            transaction.TransactionTypeId.ShouldBe(command.TransactionTypeId);
            transaction.Description.ShouldBe(command.Description);
            transaction.Amount.ShouldBe(command.Amount);
        }

        private void Cleanup()
        {
            Db.ExecuteNonQuery("DELETE FROM dbo.Transactions;");
            Db.ExecuteNonQuery("DELETE FROM dbo.Vendor;");
            Db.ExecuteNonQuery("DELETE FROM dbo.TransactionType;");
        }

        private Guid InsertTransactionType()
        {
            var id = Guid.NewGuid();
            Db.ExecuteNonQuery($"INSERT INTO dbo.TransactionType VALUES('{id}', 'Test Type');");
            return id;
        }

        private Guid InsertVendor()
        {
            var id = Guid.NewGuid();
            Db.ExecuteNonQuery($"INSERT INTO dbo.Vendor (Id, Name, DateCreated) VALUES('{id}', 'Test Vendor', GETDATE());");
            return id;
        }
    }
}