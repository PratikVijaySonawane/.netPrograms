//using AuthAndAutherizeFromC_corner.Model;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace AuthAndAutherizeFromC_corner.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private IConfiguration _config;

//        public LoginController(IConfiguration config)
//        {
//            _config = config;
//        }


//        /* Adding the Login Method with (IActionResult) */
//        [AllowAnonymous]
//        [HttpPost]
//        public IActionResult Login([FromBody] UserModel login)
//        {
//            IActionResult response = Unauthorized();
//            var user = AuthenticateUser(login);

//            if (user != null)
//            {
//                var tokenString = GenerateJSONWebToken(user);
//                response = Ok(new { token = tokenString });
//            }
//            return response;
//        }

//        /* Declaring the method to authenticate the User */
//        private UserModel AuthenticateUser(UserModel login)
//        {
//            UserModel user = null;

//            // Validate the user Credentials 
//            // Dummy data of the User 
//            if(login.Username.ToLower() == "ram")
//            {
//                user = new UserModel { Username = login.Username, 
//                                       EmailAddress = login.Username,
//                                       DateOfJoining = login.DateOfJoining
//                                     };
//            }
//            return user;
//        }

//        /* Declaring the Method to generate the jeson based token */
//        private object GenerateJSONWebToken(UserModel userInfo)
//        {
//            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

//            var claims = new[] {

//                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
//                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
//                new Claim("DateOfJoining",userInfo.DateOfJoining.ToString("yyyy-MM-dd")),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  

//            };

//            var token = new JwtSecurityToken(_config["Jwt:Issuer"], 
//                                             _config["Jwt:Issuer"],
//                                             claims,
//                                             expires: DateTime.Now.AddMinutes(120),
//                                             signingCredentials: credentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }


//    }
//}

using AuthAndAutherizeFromC_corner.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAndAutherizeFromC_corner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        /* Adding the Register Method with IActionResult */
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel model)
        {
            // Simulate saving the user to a database
            // Here you would typically validate the model and save it to your data store
            // For simplicity, we'll just return the user model with a message

            // You may add more validation logic as per your requirements
            // For example, check if the username or email already exists in the database

            // Assuming UserModel includes properties like Username, EmailAddress, Password, DateOfJoining
            var newUser = new UserModel
            {
                Username = model.Username,
                EmailAddress = model.EmailAddress,
                DateOfJoining = model.DateOfJoining // This might come from the client or be generated server-side
            };

            // Return the new user model with a success message
            return Ok(new { message = "User registered successfully", user = newUser });
        }

        /* Adding the Login Method with IActionResult */
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

       

        /* Declaring the method to authenticate the User */
        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            // Validate the user credentials
            // Dummy data of the user
            if (login.Username.ToLower() == "ram")
            {
                user = new UserModel
                {
                    Username = login.Username,
                    EmailAddress = login.Username,
                    DateOfJoining = DateTime.Now // This is just for demonstration, you might have a different logic
                };
            }
            return user;
        }

        /* Declaring the Method to generate the JSON-based token */
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("DateOfJoining", userInfo.DateOfJoining.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


