using _1toManyUsingInnerJoin.Model;
using Microsoft.EntityFrameworkCore;

namespace _1toManyUsingInnerJoin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        /* Declaring the DbContext Fields */
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }


        /* Declaring the Method to One to Many Realation */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(a => a.AuthorId);
        }
        
    }
}
