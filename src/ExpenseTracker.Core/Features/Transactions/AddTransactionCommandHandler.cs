using System.Data;
using ExpenseTracker.Core.Common.Command.Transactions;
using ExpenseTracker.Core.DataAccess.Models;
using ExpenseTracker.Core.Infrastructure.Services;
using MediatR;
using ServiceStack.OrmLite;

namespace ExpenseTracker.Core.Features.Transactions
{
    public class AddTransactionCommandHandler : RequestHandler<AddTransactionCommand>
    {
        private readonly IDbConnection _db;
        private readonly ISystemTime _systemTime;

        public AddTransactionCommandHandler(IDbConnection db, ISystemTime systemTime)
        {
            _db = db;
            _systemTime = systemTime;
        }

        protected override void HandleCore(AddTransactionCommand message)
        {
            var vendorId = _db.Scalar<int?>("SELECT Id FROM Vendor WHERE Name = @VendorName;", new { message.VendorName});

            if (!vendorId.HasValue)
            {
                vendorId = (int)_db.Insert(new Vendor
                {
                    Name = message.VendorName,
                    DateCreated = _systemTime.Now,
                }, true);
            }

            _db.Insert(new DataAccess.Models.Transactions
            {
                VendorId = vendorId.Value,
                TransactionTypeId = message.TransactionType,
                Description = message.Description,
                Amount = message.Amount,
                DateCreated = _systemTime.Now,
            });
        }
    }
}