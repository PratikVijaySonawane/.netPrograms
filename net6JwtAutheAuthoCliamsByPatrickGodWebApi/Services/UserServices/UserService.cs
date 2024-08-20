using System.Security.Claims;

namespace net6JwtAutheAuthoCliamsByPatrickGodWebApi.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
       // private readonly string result;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetmyName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext ! == null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
               
            }
            return result;    
        }
    }
}
