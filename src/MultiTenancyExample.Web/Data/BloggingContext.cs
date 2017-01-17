using Microsoft.EntityFrameworkCore;

namespace MultiTenancyExample.Web.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
