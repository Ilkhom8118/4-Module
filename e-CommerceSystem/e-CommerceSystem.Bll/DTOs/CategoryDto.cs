using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.DTOs;

public class CategoryDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
    public ICollection<CategoryDto> SubCategories { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}
