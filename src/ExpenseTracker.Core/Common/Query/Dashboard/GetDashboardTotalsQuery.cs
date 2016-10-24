using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;

namespace ExpenseTracker.Core.Common.Query.Dashboard
{
    public class GetDashboardTotalsQuery : IRequest<DashboardTotalsViewModel>
    {
    }
}
