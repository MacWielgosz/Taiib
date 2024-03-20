using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    public enum TypeEnum
    {
        Admin=0, Casual=1
    };

    [Table("Users")]
    public class User : IEntityTypeConfiguration<User>
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public TypeEnum Type { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<BasketPosition>? BasketPositions { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasMany(x => x.BasketPositions)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
