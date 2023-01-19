using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class FullstackDbContext: DbContext
    {
        public FullstackDbContext(DbContextOptions<FullstackDbContext> options) : base(options)
        {

        }
        
        public DbSet<DbArticle> myfirstdb { get; set; }
    }
}
