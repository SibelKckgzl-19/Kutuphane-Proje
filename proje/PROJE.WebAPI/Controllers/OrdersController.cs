using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Employee;
using PROJE.Model.Dtos.Order;
using PROJE.Model.Entities;

namespace PROJE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBs _orderBs;
        private readonly IMapper _mapper;
        public OrdersController(IOrderBs orderBs,IMapper mapper) 
        {
            _orderBs = orderBs;
            _mapper = mapper;
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            var response =await _orderBs.GetOrdersAsync();
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byorder")]
        public async Task<ActionResult> GetAllOrdersEmployee(int employeeId)
        {
            var response = await _orderBs.GetOrdersByEmployeeAsync(employeeId);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byshipaddress")]
        public async Task<ActionResult> GetAllOrdersShipAddress(string shipaddress)
        {
            var response =await _orderBs.GetOrdersByShipAddressAsync(shipaddress);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byshipcity")]
        public async Task<ActionResult> GetAllOrdersShipCity(string shipcity)
        {
            var response =await _orderBs.GetOrdersByShipCityAsync(shipcity);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response =await _orderBs.GetByIdAsync(id);

            return SendResponse(response);
            

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<List<OrderPostDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpPost]
        public async Task<ActionResult> SaveNewOrder([FromBody] OrderPostDto dto)
        {
            var response = await _orderBs.InsertAsync(dto);

            return SendResponse(response);

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<OrderPutDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderPutDto dto)
        {
            var response =await _orderBs.UpdateAsync(dto);

            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response =await _orderBs.DeleteAsync(id);

            return SendResponse(response);
        }








    }
}
