using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class WebshopContext : DbContext
    {

        static public DbSet<Models.BasketPosition> BasketPositions { get; set; }
        static public DbSet<Models.Order> OrderOrders { get; set; }
        static public DbSet<Models.OrderPosition> OrderPositions { get; set; }
        static public DbSet<Models.Product> Products { get; set; }
        static public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SkelpMW;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
