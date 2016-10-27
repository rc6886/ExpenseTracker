using System;
using System.Collections.Generic;

namespace ExpenseTracker.Core.ViewModels.Dashboard
{
    public class DashboardTransactionsViewModel
    {
        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }

    public class TransactionViewModel
    {
        public string Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
