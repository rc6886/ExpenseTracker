using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;

namespace ExpenseTracker.Core.Features.Dashboard
{
    public class GetDashboardTotalsQueryHandler : IRequestHandler<GetDashboardTotalsQuery, DashboardTotalsViewModel>
    {
        public DashboardTotalsViewModel Handle(GetDashboardTotalsQuery message)
        {
            return new DashboardTotalsViewModel(11.67, 113.21, 1210.09, 2298.01);
        }
    }
}
