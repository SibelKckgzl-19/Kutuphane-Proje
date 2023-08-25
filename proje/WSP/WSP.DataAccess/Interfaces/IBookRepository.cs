using Infrastructure.DataAccess;
using WSP.Model.Entities;

namespace WSP.DataAccess.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        List<Book> GetByBookName(string bookName, params string[] includeList);
        List<Book> GetByAuthor(string author, params string[] includeList);
        List<Book> GetByPrice(decimal min, decimal max, params string[] includeList);
        List<Book> GetByPublisher(int publisherID, params string[] includeList);
        
        Book GetByID(int bookID, params string[] includeList);
    }
}
