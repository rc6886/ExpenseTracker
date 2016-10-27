using System;
using System.Collections.Generic;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;

namespace ExpenseTracker.Core.Features.Dashboard
{
    public class GetDashboardTransactionsQueryHandler : IRequestHandler<GetDashboardTransactionsQuery, DashboardTransactionsViewModel>
    {
        public DashboardTransactionsViewModel Handle(GetDashboardTransactionsQuery message)
        {
            return new DashboardTransactionsViewModel
            {
                Transactions = new List<TransactionViewModel>
                {
                    new TransactionViewModel
                    {
                        Amount = 25.35M,
                        Name = "Test1",
                        TransactionDate = new DateTime(2016, 1, 1),
                        TransactionType = "Income",
                    },
                    new TransactionViewModel
                    {
                        Amount = 25.35M,
                        Name = "Test1",
                        TransactionDate = new DateTime(2016, 1, 1),
                        TransactionType = "Income",
                    },
                    new TransactionViewModel
                    {
                        Amount = 25.35M,
                        Name = "Test1",
                        TransactionDate = new DateTime(2016, 1, 1),
                        TransactionType = "Income",
                    },
                }
            };
        }
    }
}