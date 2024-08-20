using BlogApp2.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Many-to-many relationship between BlogPost and Category
            builder.Entity<Category>()
                .HasMany(c => c.BlogPosts)
                .WithMany(b => b.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "BlogPostCategory",
                    j => j.HasOne<BlogPost>().WithMany().HasForeignKey("BlogPostId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Restrict)
                );

            // One-to-many relationship between BlogPost and Comment
            builder.Entity<BlogPost>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many relationship between ApplicationUser and Comment
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many relationship between ApplicationUser and BlogPost
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.BlogPosts)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
