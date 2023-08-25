using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Entities
{
    public  class Order : IEntity
    {
        public int OrderId { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsActive { get; set; }

        public Employee? Employees { get; set; }
    }
}
