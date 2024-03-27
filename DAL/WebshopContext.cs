using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class WebshopContext : DbContext
    {
         public DbSet<Models.BasketPosition> BasketPositions { get; set; }
         public DbSet<Models.Order> Orders { get; set; }
         public DbSet<Models.OrderPosition> OrderPositions { get; set; }
         public DbSet<Models.Product> Products { get; set; }
         public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SkelpMW;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
