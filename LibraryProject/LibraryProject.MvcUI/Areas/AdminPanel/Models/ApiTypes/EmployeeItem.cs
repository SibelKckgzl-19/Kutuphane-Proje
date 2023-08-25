namespace LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class EmployeeItem
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PicturePath { get; set; }
    }
}
