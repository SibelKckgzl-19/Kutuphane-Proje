using Infrastructure.Model;

namespace PROJE.Model.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public string? PicturePath { get; set; }

        public List<Book>? Books { get; set; }
    }
}
