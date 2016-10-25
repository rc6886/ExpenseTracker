using ExpenseTracker.Core.Common.Query.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = _mediator.Send(new GetDashboardTotalsQuery());
            return View();
        }
    }
}
