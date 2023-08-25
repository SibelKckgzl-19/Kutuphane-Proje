using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using PROJE.Business.CustomExceptions;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Dtos.Order;
using PROJE.Model.Entities;

namespace PROJE.Business.Implementations
{
    public class OrderBs:IOrderBs
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderBs(IOrderRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");    

            var entity =await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList)
        {
                if (orderId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

                var order =await _repo.GetByIdAsync(orderId, includeList);

                if (order == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

                var dto = _mapper.Map<OrderGetDto>(order);

                return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
            
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList)
        {
                var orders = await _repo.GetAllAsync(x => x.IsActive == true, includeList: includeList);

                if (orders.Count > 0)
                {
                    var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                    return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }

            throw new NotFoundException("kaynak bulunamadı");

        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByEmployeeAsync(int employeeId, params string[] includeList)
        {

            if (employeeId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var orders =await _repo.GetByEmployeeAsync(employeeId, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipAddressAsync(string shipaddress, params string[] includeList)
        {
            if (shipaddress.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

            if (shipaddress == null)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");


            var orders = await _repo.GetByShipAdressAsync(shipaddress, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipCityAsync(string shipcity, params string[] includeList)
        {
            if (shipcity.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

            if (shipcity == null)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");


            var orders =await _repo.GetByShipCityAsync(shipcity, includeList);

            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto)
        {

            if (dto.ShipAddress.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

            if (dto.ShipCity.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<Order>(dto);
            entity.IsActive = true;
            var insertedOrder = await _repo.InsertAsync(entity);

            return ApiResponse<Order>.Success(StatusCodes.Status201Created, insertedOrder);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto)
        {
            if (dto.ShipAddress.Length < 2)

                    throw new BadRequestException("id pozitif bir değer olmalıdır");
 
                if (dto.ShipCity.Length < 2)

                    throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

                var entity = _mapper.Map<Order>(dto);
                entity.IsActive = true;
                _repo.UpdateAsync(entity);

                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            

            
        }
    }
}
