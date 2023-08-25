using Infrastructure.Utilities.ApiResponses;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Entities;

namespace PROJE.Business.Interfaces
{
    public interface IBookBs
    {
        Task<ApiResponse<List<BookGetDto>>> GetBooksAsync(params string[] includeList);
        Task<ApiResponse<List<BookGetDto>>> GetBooksByPriceAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<List<BookGetDto>>> GetBooksByAuthorAsync(string author, params string[] includeList);
        Task<ApiResponse<List<BookGetDto>>> GetBooksByCategoryAsync(int categoryId, params string[] includeList);


        Task<ApiResponse<BookGetDto>> GetByIdAsync(int bookId, params string[] includeList);

        Task<ApiResponse<Book>> InsertAsync(BookPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(BookPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
