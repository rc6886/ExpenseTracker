using ExpenseTracker.Core.Common.Query.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExpenseTracker.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _mediator.Send(new GetDashboardTotalsQuery());
            return View(result);
        }

        [HttpGet]
        public IActionResult PieChartCategories()
        {
            var result = _mediator.Send(new GetDashboardPieChartCategoriesQuery());
            return Json(result);
        }

        [HttpGet]
        public IActionResult Transactions()
        {
            var result = _mediator.Send(new GetDashboardTransactionsQuery());
            return Json(result);
        }
    }
}
