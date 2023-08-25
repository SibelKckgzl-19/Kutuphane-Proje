using Infrastructure.Model;

namespace PROJE.Model.Dtos.Category
{
    public class CategoryGetDto:IDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? PicturePath { get; set; }

        // public bool IsActive { get; set; }
    }
}
