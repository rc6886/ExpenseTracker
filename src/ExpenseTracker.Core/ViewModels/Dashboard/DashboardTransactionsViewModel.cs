using System;
using System.Collections.Generic;

namespace ExpenseTracker.Core.ViewModels.Dashboard
{
    public class DashboardTransactionsViewModel
    {
        public DashboardTransactionsViewModel(IEnumerable<TransactionViewModel> transactions)
        {
            Transactions = transactions;
        }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }
    }

    public class TransactionViewModel
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Vendor { get; set; }
    }
}
