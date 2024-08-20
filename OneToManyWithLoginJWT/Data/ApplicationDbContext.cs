using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneToManyWithLoginJWT.Model;

namespace OneToManyWithLoginJWT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        /* Declaring the DbSet Property */
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /* Declaring the Method for one to many relation */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
