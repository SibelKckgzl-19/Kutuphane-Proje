using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

        public string? PicturePath { get; set; }

        public bool? IsActive { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
