using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAutheticationAndAuthorization.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /* Declaring the Action Method */
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You have accesed the Admin-Controller");
        }
    }
}
