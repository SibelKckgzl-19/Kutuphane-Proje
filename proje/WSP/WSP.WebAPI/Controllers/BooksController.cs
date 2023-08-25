using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WSP.Business.Interfaces;
using WSP.Model.Dtos.Book;
using WSP.Model.Entities;

namespace WSP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookBs _bookBs;
        
        public BooksController(IBookBs bookBs, IMapper mapper)
        {
            _bookBs = bookBs;
           
        }

        #region SWAGGER DOC
        [Produces("application/json","text/plain")]
        [ProducesResponseType(200,Type= typeof(List<BookGetDto>))]
        [ProducesResponseType(404,Type= typeof(string))]
        #endregion
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            var response = _bookBs.GetBooks("Publisher");
           
            return SendResponse(response); 
        }

        [HttpGet("byauthor")]
        public ActionResult GetAllBooksByAuthor([FromQuery] string author)
        {
            var response = _bookBs.GetBooksByAuthor(author);

            return SendResponse(response);
        }

        [HttpGet("bybookname")]
        public ActionResult GetAllBooksByBookName([FromQuery] string bookName)
        {
            var response = _bookBs.GetBooksByBookName(bookName);

            return SendResponse(response);
        }

        [HttpGet("byprice")]
        public ActionResult GetAllBooksByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = _bookBs.GetBooksByPrice(min, max, "Publisher");

            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(List<BookGetDto>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion
        [HttpGet("bypublisher")]
        public ActionResult GetAllBooksByPublisher([FromRoute] int publisherID)
        {
            var response = _bookBs.GetBooksByPublisher(publisherID);

            return SendResponse(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetByID([FromRoute] int bookID)
        {
            var response = _bookBs.GetByID(bookID, "Publisher");

            return SendResponse(response);
        }

        [HttpPost]
        public ActionResult SaveNewBook([FromBody] BookPostDto dto)
        {
            var response = _bookBs.Insert(dto);

            return CreatedAtAction(nameof(GetByID), new { id = response.Data.BookID }, response.Data);
        }

        [HttpPut]

        public IActionResult UpdateBook([FromBody] BookPutDto dto)
        {
            var response = _bookBs.Update(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id) 
        {
            var response = _bookBs.Delete(id);
            return SendResponse(response);
        }
    }
}
