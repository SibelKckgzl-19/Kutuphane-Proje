using Infrastructure.DataAccess;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<List<Employee>> GetByNameAsync(string name, params string[] includeList);
        Task<List<Employee>> GetByCountryAsync(string country, params string[] includeList);
        Task<List<Employee>> GetByCityAsync(string city, params string[] includeList);
        Task<List<Employee>> GetByBirthDateAsync(DateTime birthDate, params string[] includeList);


        Task<Employee> GetByIdAsync(int employeeId, params string[] includeList);
    }
}
