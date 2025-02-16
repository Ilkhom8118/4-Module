namespace e_CommerceSystem_.Dal.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }

}
//Category(ID, Name, ParentCategoryId)