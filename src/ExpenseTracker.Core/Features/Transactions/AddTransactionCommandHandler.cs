using ExpenseTracker.Core.Common.Command.Transactions;
using MediatR;

namespace ExpenseTracker.Core.Features.Transactions
{
    public class AddTransactionCommandHandler : RequestHandler<AddTransactionCommand>
    {
        public AddTransactionCommandHandler()
        {
            
        }

        protected override void HandleCore(AddTransactionCommand message)
        {
            //Persist
        }
    }
}