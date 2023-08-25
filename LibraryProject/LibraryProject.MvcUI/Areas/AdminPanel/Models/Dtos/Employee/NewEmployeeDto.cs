namespace LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Employee
{
    public class NewEmployeeDto
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string PicturePath { get; set; }
    }
}
