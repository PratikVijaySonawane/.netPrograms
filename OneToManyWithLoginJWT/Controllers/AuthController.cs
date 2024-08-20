using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OneToManyWithLoginJWT.Data;
using OneToManyWithLoginJWT.Dtos.User;
using OneToManyWithLoginJWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OneToManyWithLoginJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /* Declaring the Fields User, and SignIn, */
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
       
        /* Declaring the Constructor for the Instance Value */
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;           
        }

        /* Declaring the Register Method */
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            /* Creating the Object of the User Model */
            var user = new User ()
            { UserName = registerDto.UserName, 
              Email = registerDto.Email 
            };

            /* Register the User With _userManager object */
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            /*Checking the result */
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);   
            }
            return Ok(new { Message = "User Registered Succesfully" });
        }

        /* Declaring the Login Method */
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            /* Finding the Name in thw DataBase */
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            /* Checking the User is null or not */
            if(user == null)
            {
                return Unauthorized();
            }

            /* Checking the Password */
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure:false);

            if(!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = GenerateToken(user);
            return Ok(new { Token=token });
        }

       
        private object GenerateToken(User user)
        {
            /*Creating the Object of the Claim */
            var Claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim (JwtRegisteredClaimNames.Email, user.Email)
            };

            /* Declaring the key ans Creds */
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            /* Declaring the Token */
            var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            Claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: creds);

            /* returning the Token */
            return new JwtSecurityTokenHandler().WriteToken(token);
          
        }
    }
}
