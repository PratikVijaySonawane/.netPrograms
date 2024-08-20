using Microsoft.AspNetCore.Mvc;

namespace RoutAttributeBasedRouting.controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
