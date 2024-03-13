using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("BasketPositions")]
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        
        [Required]
        public Product? Product { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]

        [Required]
        public User? User { get; set; }
        
        public int Amount { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.BasketPositions)
                .OnDelete(DeleteBehavior.SetNull);


            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.BasketPositions)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
