namespace ForumApp.Infrastructure.Data
{
    using ForumApp.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Post> Posts { get; set; } = null!;
    }
}