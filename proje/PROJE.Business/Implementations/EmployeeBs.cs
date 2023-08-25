using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using PROJE.Business.CustomExceptions;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Employee;
using PROJE.Model.Entities;

namespace PROJE.Business.Implementations
{
    public class EmployeeBs:IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeBs(IEmployeeRepository repo,IMapper mapper)
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

        public async Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList)
        {
                if (employeeId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır"); ;

                var employee = await _repo.GetByIdAsync(employeeId, includeList);

                if (employee == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

                var dto = _mapper.Map<EmployeeGetDto>(employee);

                return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
           
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList)
        {

                var employees = await _repo.GetAllAsync(x => x.IsActive == true, includeList: includeList);

                if (employees.Count > 0)
                {
                    var returnList =  _mapper.Map<List<EmployeeGetDto>>(employees);

                    return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }

                return ApiResponse<List<EmployeeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");
            
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByBirthDateAsync(DateTime birthdate, params string[] includeList)
        {
            if (birthdate == null)
                throw new BadRequestException("Doğum günü boş bırakılamaz");
            
            var employees = await _repo.GetByBirthDateAsync(birthdate, includeList);

            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            return ApiResponse<List<EmployeeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByCityAsync(string city, params string[] includeList)
        {
            if (city.Length < 2)
                throw new BadRequestException("Şehir adı en az 2 karakterden oluşmalıdır");

            if (city == null)
                throw new BadRequestException("Şehir adı en az 2 karakterden oluşmalıdır");


            var employees = await _repo.GetByCityAsync(city, includeList);

            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByCountryAsync(string country, params string[] includeList)
        {
            if (country.Length < 2)
                throw new BadRequestException("Ülke adı en az 2 karakterden oluşmalıdır");

            if (country == null)
                throw new BadRequestException("Ülke adı en az 2 karakterden oluşmalıdır");


            var employees =await _repo.GetByCountryAsync(country, includeList);

            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByNameAsync(string name, params string[] includeList)
        {
            if (name.Length < 2)
                throw new BadRequestException("Personel adı en az 2 karakterden oluşmalıdır");

            if (name == null)
                throw new BadRequestException("Personel adı en az 2 karakterden oluşmalıdır");


            var employees =await _repo.GetByNameAsync(name, includeList);

            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }



        public async Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto)
        {
                if (dto.Name.Length < 2)
                    throw new BadRequestException("ad soyad en az 2 karakterden oluşmalıdır");

                if (dto.Country.Length < 2)
                    throw new BadRequestException(" Ülke adı en az 2 karakterden oluşmalıdır");

                if (dto.City.Length < 2)
                    throw new BadRequestException(" Şehir adı en az 2 karakterden oluşmalıdır");
                
                if (dto.BirthDate == null)
                    throw new BadRequestException("doğum günü boş olamaz");

            var entity = _mapper.Map<Employee>(dto);
                entity.IsActive = true;
                var insertedEmployee =await _repo.InsertAsync(entity);

                return ApiResponse<Employee>.Success(StatusCodes.Status201Created, insertedEmployee);
            
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto)
        {
                if (dto.EmployeeID <= 0)
                
                    throw new BadRequestException("id pozitif bir değer olmalıdır");
 
                if (dto.Name.Length < 2)
                
                    throw new BadRequestException(" Personel adı en az 2 karakterden oluşmalıdır");
                
                if (dto.Country.Length < 2)

                    throw new BadRequestException("ülke adı en az 2 karakterden oluşmalıdır");
            
                if (dto.City.Length < 2)
              
                    throw new BadRequestException("şehir adı en az 2 karakterden oluşmalıdır");
                
                if (dto.BirtDate == null)

                    throw new BadRequestException("doğum günü boş olamaz");

            var entity = _mapper.Map<Employee>(dto);
                entity.IsActive = true;
                _repo.UpdateAsync(entity);

                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
           

               
        }
    }
}
