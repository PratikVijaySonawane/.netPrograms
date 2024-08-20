using Microsoft.AspNetCore.Mvc;

namespace SuperMarketByFrank.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
