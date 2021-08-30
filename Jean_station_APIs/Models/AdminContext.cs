using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class AdminContext : DbContext
    {
        public AdminContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=ProjectDB;integrated security=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
