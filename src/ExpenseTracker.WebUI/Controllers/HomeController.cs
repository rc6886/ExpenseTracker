using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
