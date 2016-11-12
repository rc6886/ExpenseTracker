using System.Data;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;
using ServiceStack.OrmLite;

namespace ExpenseTracker.Core.Features.Dashboard
{
    public class GetDashboardTransactionsQueryHandler : IRequestHandler<GetDashboardTransactionsQuery, DashboardTransactionsViewModel>
    {
        private readonly IDbConnection _dbConnection;

        public GetDashboardTransactionsQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DashboardTransactionsViewModel Handle(GetDashboardTransactionsQuery message)
        {
            var query = @"
                SELECT TOP 10
                    T.DateCreated AS TransactionDate
                    ,T.Amount
                    ,TT.Name AS TransactionType
                    ,V.Name AS Vendor
                FROM Transactions T
                INNER JOIN TransactionType TT
                    ON TT.Id = T.TransactionTypeId
                INNER JOIN Vendor V
                    ON V.Id = T.VendorId
                ORDER BY TransactionDate DESC";

            var transactions = _dbConnection.Select<TransactionViewModel>(query);
            return new DashboardTransactionsViewModel(transactions);
        }
    }
}