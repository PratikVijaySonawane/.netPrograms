using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
