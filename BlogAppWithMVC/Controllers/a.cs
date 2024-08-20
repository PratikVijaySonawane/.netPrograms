using Microsoft.AspNetCore.Mvc;

namespace BlogAppWithMVC.Controllers
{
    public class a : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
