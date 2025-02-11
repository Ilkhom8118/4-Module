using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram.Dal.EntityConfiguration
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(c => c.CommentId);

            builder.Property(c => c.Body)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentComentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
