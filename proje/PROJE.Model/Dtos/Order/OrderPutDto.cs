using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Model.Dtos.Order
{
    public class OrderPutDto : IDto
    {
        public int OrderId { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsActive { get; set; }
    }
    }
