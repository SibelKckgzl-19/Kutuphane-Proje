using Infrastructure.DataAccess.EF;
using System.Net;
using WSP.DataAccess.Implementations.EF.Contexts;
using WSP.DataAccess.Interfaces;
using WSP.Model.Entities;

namespace WSP.DataAccess.Implementations.EF.Repositories
{
    public class BookRepository : BaseRepository<Book, LibraryContext>, IBookRepository
    {
        public List<Book> GetByAuthor(string author, params string[] includeList)
        {
            return GetAll(bks => bks.Author == author, includeList);
        }


        public Book GetByID(int bookID, params string[] includeList)
        {
            return Get(bks => bks.BookID == bookID, includeList);
        }

        public List<Book> GetByBookName(string bookName, params string[] includeList)
        {
            return GetAll(bks => bks.BookName == bookName, includeList);
        }

      
        public List<Book> GetByPrice(decimal min, decimal max, params string[] includeList)
        {
            return GetAll(bks => bks.Price > min && bks.Price < max, includeList);
        }

        public List<Book> GetByPublisher(int publisherID, params string[] includeList)
        {
            return GetAll(bks => bks.PublisherID == publisherID, includeList);
        }

       
    }
}
