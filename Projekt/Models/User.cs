using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    public enum TypUser
    {
        Admin = 0, Casual = 1
    };

    [Table("Users")]
    public class User : IEntityTypeConfiguration<User>
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public TypUser Type { get; set; }
        public List<Order> Orders { get; set; } = new();
        public List<BasketPosition> BasketPositions { get; set; } = new();

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(x => x.BasketPositions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
