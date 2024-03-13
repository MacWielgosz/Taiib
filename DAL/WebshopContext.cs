using Microsoft.EntityFrameworkCore;

namespace DAL
{

    public class WebshopContext : DbContext
    {
        
        public DbSet<Model.BasketPosition> BasketPositions { get; set; }
        public DbSet<Model.Order> OrderOrders { get; set; }
        public DbSet<Model.OrderPosition> OrderPositions { get; set; }
        public DbSet<Model.Product> Products { get; set; }
        public DbSet<Model.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=WykladDb; Trusted_Connection = True");
 }
    }
}
