using System;
using System.Data;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.Infrastructure.Services;
using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;
using ServiceStack.OrmLite;

namespace ExpenseTracker.Core.Features.Dashboard
{
    public class GetDashboardTotalsQueryHandler : IRequestHandler<GetDashboardTotalsQuery, DashboardTotalsViewModel>
    {
        private readonly IDbConnection _db;
        private readonly ISystemTime _systemTime;

        public GetDashboardTotalsQueryHandler(IDbConnection db, ISystemTime systemTime)
        {
            _db = db;
            _systemTime = systemTime;
        }

        public DashboardTotalsViewModel Handle(GetDashboardTotalsQuery message)
        {
            var today = _systemTime.Now.Date;
            var startOfWeek = today.AddDays(-(int) today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);
            var beginningOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            var totalSpentoday =
                _db.Scalar<decimal>(
                    @"SELECT SUM(Amount) FROM Transactions WHERE TransactionTypeId = 2 AND CAST(DateCreated AS DATE) = @Today;",
                    new {Today = today});

            var totalSpentThisWeek =
                _db.Scalar<decimal>(
                    @"SELECT SUM(Amount) FROM Transactions WHERE TransactionTypeId = 2 AND DateCreated BETWEEN @StartOfWeek AND @EndOfWeek",
                    new {StartOfWeek = startOfWeek, EndOfWeek = endOfWeek});

            var totalSpentThisMonth =
                _db.Scalar<decimal>(
                    @"SELECT SUM(Amount) FROM Transactions WHERE TransactionTypeId = 2 AND DateCreated BETWEEN @BeginningOfMonth AND @EndOfMonth;",
                    new {BeginningOfMonth = beginningOfMonth, EndOfMonth = endOfMonth});

            var totalIncomeThisMonth =
                _db.Scalar<decimal>(
                    @"SELECT SUM(Amount) FROM Transactions WHERE TransactionTypeId = 1 AND DateCreated BETWEEN @BeginningOfMonth AND @EndOfMonth;",
                    new {BeginningOfMonth = beginningOfMonth, EndOfMonth = endOfMonth});

            return new DashboardTotalsViewModel(totalSpentoday, totalSpentThisWeek, totalSpentThisMonth, totalIncomeThisMonth);
        }
    }
}
