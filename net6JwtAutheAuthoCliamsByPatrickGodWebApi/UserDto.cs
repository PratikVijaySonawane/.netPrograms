namespace net6JwtAutheAuthoCliamsByPatrickGodWebApi
{
    /* Creating the UserDto(Data Transfer Object) class for Login and Registration */
    public class UserDto
    {
        /* Declaring the Attributes */
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
