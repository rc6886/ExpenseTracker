using ExpenseTracker.Core.Common.Command.Transactions;
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

        [HttpPost]
        public IActionResult AddTransaction([FromBody] AddTransactionCommand command)
        {
            _mediator.Send(command);
            return new OkResult();
        }
    }
}
