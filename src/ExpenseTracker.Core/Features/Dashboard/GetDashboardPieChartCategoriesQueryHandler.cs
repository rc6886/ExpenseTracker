using System.Collections.Generic;
using ExpenseTracker.Core.Common.Query.Dashboard;
using ExpenseTracker.Core.ViewModels.Dashboard;
using MediatR;

namespace ExpenseTracker.Core.Features.Dashboard
{
    public class GetDashboardPieChartCategoriesQueryHandler : IRequestHandler<GetDashboardPieChartCategoriesQuery, DashboardPieChartViewModel>
    {
        public DashboardPieChartViewModel Handle(GetDashboardPieChartCategoriesQuery message)
        {
            return new DashboardPieChartViewModel
            {
                PieChartCategories = new List<PieChartCategory>
                {
                    new PieChartCategory("Food", 25),
                    new PieChartCategory("Rent", 50),
                    new PieChartCategory("Other", 25),
                }
            };
        }
    }
}