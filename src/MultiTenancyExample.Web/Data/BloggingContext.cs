using Microsoft.EntityFrameworkCore;

namespace MultiTenancyExample.Web.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
