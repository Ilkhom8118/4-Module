using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_CommerceSystem_.Dal.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentCategoryId);
        builder.HasMany(c => c.SubCategories).WithOne(c => c.ParentCategory).HasForeignKey(c => c.ParentCategoryId);
        builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.NoAction);
    }
}
