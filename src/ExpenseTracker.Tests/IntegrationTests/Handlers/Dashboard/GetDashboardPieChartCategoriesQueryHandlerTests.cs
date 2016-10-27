using System.Linq;
using ExpenseTracker.Core.Common.Query.Dashboard;
using NUnit.Framework;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Dashboard
{
    [TestFixture]
    public class GetDashboardPieChartCategoriesQueryHandlerTests : BaseTest
    {
        [Test]
        public void Should_get_correct_pie_chart_categories_and_percentages()
        {
            var query = new GetDashboardPieChartCategoriesQuery();
            var result = Mediator.Send(query);

            result.PieChartCategories.Count().ShouldBe(3);

            result.PieChartCategories.ElementAt(0).CategoryName.ShouldBe("Food");
            result.PieChartCategories.ElementAt(0).PercentageOfExpenses.ShouldBe(25);

            result.PieChartCategories.ElementAt(1).CategoryName.ShouldBe("Rent");
            result.PieChartCategories.ElementAt(1).PercentageOfExpenses.ShouldBe(50);

            result.PieChartCategories.ElementAt(2).CategoryName.ShouldBe("Other");
            result.PieChartCategories.ElementAt(2).PercentageOfExpenses.ShouldBe(25);
        }
    }
}
