using System.Data;
using ExpenseTracker.Core.Common.Command.Transactions;
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
            _db.Insert(new DataAccess.Models.Transactions
            {
                Id = message.Id,
                VendorId = message.VendorId,
                TransactionTypeId = message.TransactionTypeId,
                Description = message.Description,
                Amount = message.Amount,
                DateCreated = _systemTime.Now,
            });
        }
    }
}