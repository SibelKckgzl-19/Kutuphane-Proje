using Infrastructure.Utilities.ApiResponses;
using System.Xml.Linq;
using WSP.Model.Dtos.Book;
using WSP.Model.Entities;

namespace WSP.Business.Interfaces
{
    public interface IBookBs
    {
        ApiResponse<List<BookGetDto>> GetBooks(params string[] includeList);
        ApiResponse<List<BookGetDto>> GetBooksByAuthor(string author, params string[] includeList);
        ApiResponse<List<BookGetDto>> GetBooksByBookName(string bookName, params string[] includeList);
        ApiResponse<List<BookGetDto>> GetBooksByPrice(decimal min, decimal max, params string[] includeList);
        ApiResponse<List<BookGetDto>> GetBooksByPublisher(int publisherID ,params string[] includeList);

        ApiResponse<BookGetDto> GetByID(int bookID, params string[] includeList);

        ApiResponse<Book> Insert (BookPostDto dto);
        ApiResponse<NoData> Update (BookPutDto dto);
        ApiResponse<NoData> Delete (int id);
    }
}
