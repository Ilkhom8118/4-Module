using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User).WithOne(u => u.Carts).HasForeignKey<Cart>(c => c.UserId);
            builder.HasMany(c => c.CartProducts).WithOne(cp => cp.Cart).HasForeignKey(c => c.CartId);

        }
    }
}
