using Microsoft.EntityFrameworkCore;

namespace WebApplicationEF.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Details> Detailss { get; set; }
    }
}
