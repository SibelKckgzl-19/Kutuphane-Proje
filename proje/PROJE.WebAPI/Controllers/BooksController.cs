using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJE.Business.Implementations;
using PROJE.Business.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Entities;

namespace PROJE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookBs _bookBs;
        private readonly IMapper _mapper;

        public BooksController(IBookBs bookBs, IMapper mapper)
        {
            _bookBs = bookBs;
            _mapper = mapper;
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet]
        public async  Task<ActionResult> GetAllBooks()
        {
            var response =await _bookBs.GetBooksAsync("Category");
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bycategory")]
        public async Task<ActionResult> GetAllBooksCategory([FromQuery] int categoryId)
        {
            var response = await _bookBs.GetBooksByCategoryAsync(categoryId);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byprice")]
        public async Task<ActionResult> GetAllBooksPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _bookBs.GetBooksByPriceAsync(min, max);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("byauthor")]
        public async Task<ActionResult> GetAllBooksAuthor([FromQuery] string author)
        {
            var response = await _bookBs.GetBooksByAuthorAsync(author);
            return SendResponse(response);
        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _bookBs.GetByIdAsync(id, "Category");
            return SendResponse(response);

        }

        #region
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(201, Type = typeof(ApiResponse<List<BookPostDto>>))]
        [ProducesResponseType(400, Type = typeof(string))]
        #endregion
        [HttpPost]
        public async Task<ActionResult> SaveNewBook([FromBody] BookPostDto dto)
        {
            var response = await _bookBs.InsertAsync(dto);

            return SendResponse(response);


        }

        [HttpPut]
        public async  Task<IActionResult> UpdateProduct([FromBody] BookPutDto dto)
        {
            var response =await _bookBs.UpdateAsync(dto);

            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response =await  _bookBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
