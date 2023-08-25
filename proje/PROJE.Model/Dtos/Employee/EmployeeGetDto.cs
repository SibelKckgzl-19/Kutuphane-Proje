using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Dtos.Employee
{
    public class EmployeeGetDto : IDto
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PicturePath { get; set; }
        public bool? IsActive { get; set; }

    }
}
