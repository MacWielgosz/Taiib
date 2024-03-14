using Microsoft.EntityFrameworkCore;

namespace DAL
{

    public class WebshopContext : DbContext
    {

        public DbSet<Models.BasketPosition> BasketPositions { get; set; }
        public DbSet<Models.Order> OrderOrders { get; set; }
        public DbSet<Models.OrderPosition> OrderPositions { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=WykladDb; Trusted_Connection = True");
        }
    }
}
