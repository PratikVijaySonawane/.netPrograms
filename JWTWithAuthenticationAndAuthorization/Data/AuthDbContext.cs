using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTWithAuthenticationAndAuthorization.Data
{
    /* Declaring the class for The Identity of the user */
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        /* Declaring the Constructor */
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
