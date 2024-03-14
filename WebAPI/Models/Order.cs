using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Orders")]

    public class Order : IEntityTypeConfiguration<Order>
    {
        [Key]

        public int ID { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderPosition>? OrderPositions { get; set; }


        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                 .HasOne(x => x.User)
                 .WithMany(x => x.Orders)
                 .OnDelete(DeleteBehavior.SetNull);

            builder
                 .HasOne(x => x.User)
                 .WithMany(x => x.Orders)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
