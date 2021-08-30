using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class CartContext : DbContext
    {
        public CartContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=ProjectDB;integrated security=true");
        }

        public DbSet<Cart> Carts { get; set; }
    }
}
