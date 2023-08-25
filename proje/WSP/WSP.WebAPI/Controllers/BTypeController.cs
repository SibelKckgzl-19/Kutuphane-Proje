using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WSP.Business.Interfaces;
using WSP.Model.Dtos.BType;
using WSP.Model.Entities;

namespace WSP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BTypeController : BaseController
    {
        private readonly IBTypeBs _bTypeBs;

        public BTypeController(IBTypeBs bTypeBs, IMapper mapper)
        {
            _bTypeBs = bTypeBs;
        }

        [HttpGet]
        public ActionResult GetAllBTypes()
        {
            var response = _bTypeBs.GetBTypes("Book");
            return SendResponse(response);
        }

        [HttpGet("bybookname")]
        public ActionResult GetAllBTypesByBookName([FromQuery] string bookName)
        {
            var response = _bTypeBs.GetBTypesByBookName("BookName");
            return SendResponse(response);
        }

        [HttpGet("bybooktype")]
        public ActionResult GetAllBTypesByBookType([FromQuery] string bookName)
        {
            var response = _bTypeBs.GetBTypesByBookType("BookType");
            return SendResponse(response);
        }

        [HttpGet("(bybook")]
        public ActionResult GetAllBTypesByBook([FromRoute] int bookID)
        {
            var response = _bTypeBs.GetBTypesByBook(bookID);
            return SendResponse(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetByID([FromRoute] int bookTypeID)
        {
            var response = _bTypeBs.GetByID(bookTypeID, "Book");
            return SendResponse(response);
        }


        [HttpPost]
        public ActionResult SaveNewBType([FromBody] BTypePostDto dto)
        {
            var response = _bTypeBs.Insert(dto);
            return CreatedAtAction (nameof(GetByID), new { id = response.Data.BookTypeID }, response.Data);

        }

        [HttpPut]
        public IActionResult UpdateBType([FromBody] BTypePutDto dto) 
        {
            var response = _bTypeBs.Update(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBType (int id)
        {
            var response = _bTypeBs.Delete(id);
            return SendResponse(response);
        }
    }
}
