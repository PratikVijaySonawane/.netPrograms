
using Microsoft.EntityFrameworkCore;
using ProductModuleFrom_C_Corner.Model;

namespace ProductModuleFrom_C_Corner.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        /* Declaring the DbSet */
        public DbSet<Products> Products { get; set; }  
    }


}
