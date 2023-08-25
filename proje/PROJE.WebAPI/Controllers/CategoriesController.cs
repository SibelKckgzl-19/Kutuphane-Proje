using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Category;
using PROJE.Model.Entities;

namespace PROJE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBs _categoryBs;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryBs categoryBs, IMapper mapper)
        {
            _categoryBs = categoryBs;
            _mapper = mapper;
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllCategories()
        {

            var response = await _categoryBs.GetCategoriesAsync();
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bydesc")]
        public async Task<ActionResult> GetAllCategoryDescription([FromQuery] string desc)
        {
            var response = await _categoryBs.GetCategoriesByDescriptionAsync(desc);
            return SendResponse(response);

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _categoryBs.GetByIdAsync(id);

            return SendResponse(response);

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<List<CategoryPostDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpPost]
        public async Task<ActionResult> SaveNewCategory([FromBody] CategoryPostDto dto)
        {
            var response = await _categoryBs.InsertAsync(dto);

            return SendResponse(response);

        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var response = await _categoryBs.UpdateAsync(dto);

            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response =await _categoryBs.DeleteAsync(id);

            return SendResponse(response);
        }


    }
    }
