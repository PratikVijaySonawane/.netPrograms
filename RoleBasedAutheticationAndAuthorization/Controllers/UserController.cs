using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAutheticationAndAuthorization.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /* Declaring the Action Method */
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You have accessed the User-Controller");
        }
    }
}
