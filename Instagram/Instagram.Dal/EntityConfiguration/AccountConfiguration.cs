using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram.Dal.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(a => a.AccountId);

            builder.Property(a => a.UserName).IsRequired(true);

            builder.HasIndex(a => a.UserName).IsUnique();

            builder.Property(a => a.Bio)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasMany(a => a.Posts)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Comments)
                .WithOne(c => c.Account) // Corrected navigation property reference
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Followers)
                .WithMany(a => a.Following);
        }
    }
}
