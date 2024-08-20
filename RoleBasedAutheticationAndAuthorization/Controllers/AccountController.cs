using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using RoleBasedAutheticationAndAuthorization.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAutheticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /* Declaring the private readonly Fields */
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        /* Adding the Parameterized Constructor */
        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        /* Creating the Register Method */
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDetails model )
        {
            var user = new IdentityUser { UserName = model.UserName };

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                return Ok(new { message = "User registered Succesfuly" });
            }
            return BadRequest(result.Errors);   
        }

        /* Creating the Login Method */
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDetails model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user != null && await _userManager.CheckPasswordAsync(user, model.Password))                                                
            {
                /* Creating the User Role */
                var userRole = await _userManager.GetRolesAsync(user);

                /* Declaring the auth claims */
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };

                /* Declaring the AddRange method */
                authClaims.AddRange(userRole.Select(role=> new Claim(ClaimTypes.Role, role)));

                /* creating the object of the (JwtSecurityToken) */
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!)), 
                                                                                    SecurityAlgorithms.HmacSha256)
                    );

                /*returning the Ok() Method In the Method We will give the parameters  */
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token)});
            }

            /* In else part we will Returning the Unauthorized method */
            return Unauthorized();   
        }

        /* Creating the Add-Role Method */
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody]string role)
        {
            /* This will check if role is exist or not? */
            if(!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role));
                if(result.Succeeded)
                {
                    return Ok(new { message = "Role Added Successfully"});
                }
                return BadRequest();
            }
            return BadRequest("Role already Exist");
        }

        /* Creating the Assign-Role Method */
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRole model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            /* Checking if user is null or not */
            if(user == null)
            {
                return BadRequest("User Not Found");
            }

            /* AddToRole() --> this will add the specified user to the Role  */
            var result = await _userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned Successfully" });
            }
            return BadRequest(result.Errors);
        }
    }
}
