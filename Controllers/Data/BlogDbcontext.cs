using Microsoft.EntityFrameworkCore;
using CrochetJournal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace CrochetJournal.Data
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        { }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}