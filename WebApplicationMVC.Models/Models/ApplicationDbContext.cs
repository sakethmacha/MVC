using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Details> Detailss { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //             .HasOne(o => o.Status)
            //             .WithMany()
            //             .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus
                {
                    Id = 1,
                    Name = "Pending",
                    Description = "Order is waiting to be processed"
                },
                new OrderStatus
                {
                    Id = 2,
                    Name = "Processing",
                    Description = "Order is currently being prepared"
                },
                new OrderStatus
                {
                    Id = 3,
                    Name = "Completed",
                    Description = "Order has been completed"
                },
                new OrderStatus
                {
                    Id = 4,
                    Name = "Cancelled",
                    Description = "Order has been cancelled by the user or admin"
                }
            );
        }
    }
}
