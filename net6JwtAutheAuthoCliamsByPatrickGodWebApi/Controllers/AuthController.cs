using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Numerics;


namespace net6JwtAutheAuthoCliamsByPatrickGodWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        /* Creating the Instance of the User Model class,Which is static */
        public static User user = new User();

        /* generating the Instance of the IConfiguration interface */
        private readonly IConfiguration _configuration;
        private readonly IUserService _userservice;



        /* Creating the Constructor for configuration object */
        public AuthController(IConfiguration configuration, IUserService userservice)
        {
            _configuration = configuration;
            _userservice = userservice;
        }

        /* Creating the GetMe() Method */
        [HttpGet,Authorize]
        public ActionResult<string> GetMe()
        {
            /* Method-1*/
            /* We can send name by userservice object */
            var userName = _userservice.GetmyName();
            return Ok(userName);

            /* We can also send the data by Method-2 */
            //var userName = User?.Identity?.Name;
            //var roles = User?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);/* (This Method will return the UserRole) */

            //var userDetail = new 
            //{
            //    UserName = userName,
            //    Roles = roles
            //};
            //return Ok(userDetail);
        }

        /* creating the Register Method */
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.UserName = request.UserName;
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;
            return Ok(user);    
        }

        /* Creating the Method for login user */
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if(user.UserName != request.UserName)
            {
                return BadRequest("User Not Found....");
            }

            if(!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) 
            {
                return BadRequest("Wrong Password.....");
            }

            /* Declaring the Method to create the Token */
            string token = CreateToken(user);
            return Ok(token);
        }

        /* Defining the private method CreateToken() */
        private string CreateToken(User user)
        {
            /* Creating the claims */
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,"User"),
            };  

            /* Declaring the key to Generate the Token */
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            /* Declaring the cred variable */
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            /* Declaring the token variable */
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            /* Declaring the jwt variable */
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

       
        /* Creating the Method CreatePasswordHash() */
        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt) 
        { 
            /* creating the using Method */
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));      
            }
        }

        /* Creating the Method to verify the Password */
        private bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            /* Creating the using() to verify the Password */
            using (var hmac = new HMACSHA512(PasswordSalt)) 
            {
                var CompHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));  
                return CompHash.SequenceEqual(PasswordHash);
            }
        } 
    }
}
