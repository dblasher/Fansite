using FanSite.Models;
using Microsoft.EntityFrameworkCore;

namespace FanSite.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base (options){}   
        
        public DbSet<StoryResponse> Stories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Link> Links { get; set; }
    }
}
