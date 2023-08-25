using Infrastructure.Utilities.ApiResponses;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Order;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Interfaces
{
    public interface IOrderBs
    {
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipAddressAsync(string shipaddress, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipCityAsync(string shipcity, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersByEmployeeAsync(int employeeId, params string[] includeList);


        Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList);

        Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
