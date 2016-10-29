using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebUI.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult AddTransaction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTransaction()
        {
            
        }
    }
}
