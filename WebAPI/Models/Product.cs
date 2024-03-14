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
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPosition>? BasketPositions { get; set; }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(x => x.BasketPositions)
                .WithOne(x => x.Product)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
