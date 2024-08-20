using Microsoft.AspNetCore.Mvc;

namespace RoutAttributeBasedRouting.controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("~/Home")]
        public IActionResult Index()
        {
            return View();
        }

        /* Declaring the method for the About */
        /* Adding the Route*/
        public IActionResult About()
        {
            return View();
        }

        /* Declaring the Method for the Details */
        /* Adding the Route*/
        [Route("{id?}")]
        public int Details(int id=1)
        {
            return id ;
        }
    }
}
