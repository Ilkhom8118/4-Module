namespace e_CommerceSystem.Bll.DTOs
{
    public class CategoryUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }
    }
}
