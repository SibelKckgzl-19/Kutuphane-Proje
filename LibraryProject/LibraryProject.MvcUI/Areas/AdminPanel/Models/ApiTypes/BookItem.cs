namespace LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class BookItem
    {
        public string CategoryId { get; set; }
        public int BookId { get; set; } 
        public string BookName { get; set; }
        public string Author { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string PicturePath { get; set; }
    }
}
