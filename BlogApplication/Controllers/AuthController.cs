using BlogApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _cofiguration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cofiguration = configuration;          
        }

        /* Declaring the Register Method */
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok(new { message = "User Registered Successfully"});
        }


        /* Declaring the Login-Model */
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /* Find The User by its Email */
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return Unauthorized(new { message = "Invalid Email or Password " });
            }

            /* Declaring the Method to check the Password */
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid Email or Password " });
            }

            var token = GenerateJwtToken(user);
            return Ok(new { token });

        }

        private object GenerateJwtToken(ApplicationUser user)
        {
            /* Declaring the Claims */
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };

            /* Declaring the Key */
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cofiguration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            /* Declaring the Token */
            var token = new JwtSecurityToken(             
                issuer : _cofiguration["Jwt:Issuer"],
                audience: _cofiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow,   
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
