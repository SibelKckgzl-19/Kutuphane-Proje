using Infrastructure.DataAccess.EF;
using PROJE.DataAccess.Implementations.EF.Contexts;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.DataAccess.Implementations.EF.Repositories
{
    public class OrderRepository : BaseRepositoryEf<Order, LibraryContext>, IOrderRepository
    {
        public async Task<List<Order>> GetByEmployeeAsync(int employeeId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.EmployeeId == employeeId, includeList);
        }

        public async Task<Order> GetByIdAsync(int orderId, params string[] includeList)
        {
            return await GetAsync(prd => prd.OrderId == orderId, includeList);
        }

        public async Task<List<Order>> GetByShipAdressAsync(string shipaddress, params string[] includeList)
        {
            return await GetAllAsync(ord => ord.ShipAddress == shipaddress);
        }

        public async Task<List<Order>> GetByShipCityAsync(string shipcity, params string[] includeList)
        {
            return await GetAllAsync(ord => ord.ShipCity == shipcity);
        }

       
    }
}
