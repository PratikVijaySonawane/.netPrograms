using Microsoft.AspNetCore.Mvc;

namespace A.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
