using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Category;
using PROJE.Model.Dtos.Employee;
using PROJE.Model.Entities;

namespace PROJE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeBs _employeeBs;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeBs employeeBs, IMapper mapper) 
        {
            _employeeBs = employeeBs;
            _mapper = mapper;
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var response =await _employeeBs.GetEmployeesAsync();
            return SendResponse(response);
        }


        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byname")]
        public async Task<ActionResult> GetAllEmployeesName(string name)
        {
            var response = await _employeeBs.GetEmployeesByNameAsync(name);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bycountry")]
        public async Task<ActionResult> GetAllEmployeesCountry(string country)
        {
            var response = await _employeeBs.GetEmployeesByCountryAsync(country);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bycity")]
        public async Task<ActionResult> GetAllEmployeesCity(string city)
        {
            var response = await _employeeBs.GetEmployeesByCityAsync(city);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bybirthdate")]
        public async Task<ActionResult> GetAllEmployeesBirthDate(DateTime birthdate)
        {
            var response = await _employeeBs.GetEmployeesByBirthDateAsync(birthdate);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response =await _employeeBs.GetByIdAsync(id);

            return SendResponse(response);

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<List<EmployeePostDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpPost]
        public async Task<ActionResult> SaveNewEmployee([FromBody] EmployeePostDto dto)
        {
            var response =await _employeeBs.InsertAsync(dto);

            return SendResponse(response);


        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeePutDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeePutDto dto)
        {
            var response =await _employeeBs.UpdateAsync(dto);

            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _employeeBs.DeleteAsync(id);

            return SendResponse(response);
        }













    }
}
