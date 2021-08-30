using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=ProjectDB;integrated security=true");
        }

        public DbSet<Order> Orders { get; set; }
    }
}
