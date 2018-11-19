using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DummyAPI.Persistence
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<BlogRecord> Blogs { get; set; }
        public DbSet<PostRecord> Posts { get; set; }
        public DbSet<AuthorRecord> Authors { get; set; }
    }
}
