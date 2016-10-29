using System;
using MediatR;

namespace ExpenseTracker.Core.Common.Command.Transactions
{
    public class AddTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
    }
}