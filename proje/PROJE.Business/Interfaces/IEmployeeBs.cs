using Infrastructure.Utilities.ApiResponses;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Employee;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Interfaces
{
    public interface IEmployeeBs
    {
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByCountryAsync(string country, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesByBirthDateAsync(DateTime birthdate, params string[] includeList);



        Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList);

        Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);


    }
}
