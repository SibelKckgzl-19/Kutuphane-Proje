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
    public class EmployeeRepository : BaseRepositoryEf<Employee, LibraryContext>, IEmployeeRepository
    {
        public async Task<List<Employee>> GetByBirthDateAsync(DateTime birthDate, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.BirthDate == birthDate);
        }

        public async Task<List<Employee>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.City == city);
        }

        public async Task<List<Employee>> GetByCountryAsync(string country, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.Country == country);
        }

        public async Task<Employee> GetByIdAsync(int employeeId, params string[] includeList)
        {
            return await GetAsync(prd => prd.EmployeeID == employeeId, includeList);
        }

        public async Task<List<Employee>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.Name == name);
        }

       
    }
}
