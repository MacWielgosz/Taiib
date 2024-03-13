using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Model
{
    [Table("OrderPositions")]
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        [Key]

        public int ID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]

        public Order? Order { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderPositions)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
