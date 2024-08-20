using BloggingApplicationWithDarpan.Model;
using Microsoft.EntityFrameworkCore;

namespace BloggingApplicationWithDarpan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /* Declaring the DbSets */
        public DbSet<User> Users { get; set; } 
        public DbSet<Category> Categories { get; set; }    
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }   

        /* Declaring the Method for One to Many RelationShip */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to many Between User to Author
            modelBuilder.Entity<User>()
                        .HasMany(u => u.BlogPosts)
                        .WithOne(a => a.Author)
                        .HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Restrict); 

            // One to many bet User to Comments
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Comments)
                        .WithOne(a => a.Author)
                        .HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Restrict); 

            // One to many bet Category to BlogPost 
            modelBuilder.Entity<Category>()
                        .HasMany(u => u.BlogPosts)
                        .WithOne(a => a.Category)
                        .HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Restrict); 
            
            // One to many between BlogPost and Comments
            modelBuilder.Entity<BlogPost>()
                        .HasMany(b => b.comments)
                        .WithOne(a => a.BlogPost)
                        .HasForeignKey(a => a.BlogPostId).OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
