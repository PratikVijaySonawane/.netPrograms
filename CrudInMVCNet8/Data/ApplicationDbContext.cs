using CrudInMVCNet8.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudInMVCNet8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        /* Declaring the Fields */
        public DbSet<Student> Students { get; set; }
    }
}
