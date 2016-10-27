using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;

namespace ExpenseTracker.Core.Common.Query.Dashboard
{
    public class GetDashboardTransactionsQuery : IRequest<DashboardTransactionsViewModel>
    {
    }
}
