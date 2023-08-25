namespace LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public int EmployeeId { get; set; }
        public string PicturePath { get; set; }
    }
}
