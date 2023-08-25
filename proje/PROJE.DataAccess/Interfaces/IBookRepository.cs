using Infrastructure.DataAccess;
using PROJE.Model.Entities;

namespace PROJE.DataAccess.Interfaces
{
    public interface IBookRepository:IBaseRepository<Book>
    {
        Task<List<Book>> GetByPriceAsync(decimal min, decimal max, params string[] includeList);
        Task<List<Book>> GetByAuthorAsync(string author, params string[] includeList);
        Task<List<Book>> GetByCategoryAsync(int categoryId, params string[] includeList);

        Task<Book> GetByIdAsync(int bookId, params string[] includeList);
    }
}
