using Infrastructure.DataAccess;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.DataAccess.Interfaces
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<List<Order>> GetByShipAdressAsync(string shipaddress, params string[] includeList);
        Task<List<Order>> GetByShipCityAsync(string shipcity, params string[] includeList);
        Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList);

        Task<Order> GetByIdAsync(int orderId, params string[] includeList);
    }
}
