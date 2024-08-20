namespace net6JwtAutheAuthoCliamsByPatrickGodWebApi
{
    /*Crated the User class as Model to set nad get the data */
    public class User
    {
        /* Declaring the Fields */
        public string UserName { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
