using CRUDWithStoredProcedure.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithStoredProcedure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
