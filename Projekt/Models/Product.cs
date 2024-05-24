using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Products")]
    public class Product : IEntityTypeConfiguration<Product>
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public List<BasketPosition> BasketPositions { get; set; } = new();
        public List<OrderPosition> OrderPositions { get; set; } = new();

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(x => x.BasketPositions)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.OrderPositions)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
