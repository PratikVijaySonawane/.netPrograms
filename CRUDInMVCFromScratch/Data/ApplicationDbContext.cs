using CRUDInMVCFromScratch.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDInMVCFromScratch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /* Declaring the Fields */
        DbSet<Employees> Employees { get; set; }    
    }
}
