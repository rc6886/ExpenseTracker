using System;
using MediatR;

namespace ExpenseTracker.Core.Common.Command.Transactions
{
    public class AddTransactionCommand : IRequest
    {
        public string VendorName { get; set; }
        public int TransactionType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}