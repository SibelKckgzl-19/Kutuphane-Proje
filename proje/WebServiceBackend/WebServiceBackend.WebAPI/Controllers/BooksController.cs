using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceBackend.WebAPI.Data;
using WebServiceBackend.WebAPI.Model.Entities;

namespace WebServiceBackend.WebAPI.Controllers
{
    [Route("api/[controller]")] //../api/books
    [ApiController]
    public class BooksController : ControllerBase
    {
        public List<Book> GetAll()
        {
            var context = new LibraryContext();

            var books= context.Books.ToList();
            return books;
        }
    }
}
