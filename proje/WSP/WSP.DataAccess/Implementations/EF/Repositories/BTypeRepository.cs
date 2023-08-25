using Infrastructure.DataAccess.EF;
using WSP.DataAccess.Implementations.EF.Contexts;
using WSP.DataAccess.Interfaces;
using WSP.Model.Entities;

namespace WSP.DataAccess.Implementations.EF.Repositories
{
    public class BTypeRepository : BaseRepository<BType, LibraryContext>, IBTypeRepository
    {
        public List<BType> GetByBook(int bookID, params string[] includeList)
        {
            return GetAll(btp => btp.BookID == bookID, includeList);
        }

        public List<BType> GetByBookName(string bookName, params string[] includeList)
        {
            return GetAll(btp => btp.BookType == bookName, includeList);
        }

        public List<BType> GetByBookType(string bookType, params string[] includeList)
        {
            return GetAll(btp => btp.BookType == bookType, includeList);
        }

        public BType GetByID(int bookTypeID, params string[] includeList)
        {
            return Get(btp=> btp.BookTypeID == bookTypeID, includeList);
        }
    }
}
