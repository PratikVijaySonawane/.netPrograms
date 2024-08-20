using CRUDwith.net8WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDwith.net8WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        /* Declaring the ApplicationDbContext class(child-class of DbContext class) */
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        /* Declaring the Dbset<Model-class> properties */
        public DbSet<Employee> Employees { get; set; }


    }
}
