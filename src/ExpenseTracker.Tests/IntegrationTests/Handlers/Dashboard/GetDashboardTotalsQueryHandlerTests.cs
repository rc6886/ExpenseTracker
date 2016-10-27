using ExpenseTracker.Core.Common.Query.Dashboard;
using NUnit.Framework;
using Shouldly;

namespace ExpenseTracker.Tests.IntegrationTests.Handlers.Dashboard
{
    [TestFixture]
    public class GetDashboardTotalsQueryHandlerTests : BaseTest
    {
        [Test]
        public void Should_get_correct_totals()
        {
            var query = new GetDashboardTotalsQuery();
            var result = Mediator.Send(query);

            result.TotalSpentToday.ShouldBe(11.67);
            result.TotalSpentThisWeek.ShouldBe(113.21);
            result.TotalSpentThisMonth.ShouldBe(1210.09);
            result.TotalIncomeThisMonth.ShouldBe(2298.01);
        }
    }
}