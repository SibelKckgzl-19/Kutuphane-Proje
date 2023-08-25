using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSP.Model.Entities;

namespace WSP.DataAccess.Interfaces
{
    public interface IBTypeRepository : IBaseRepository<BType>
    {
        List<BType> GetByBookType(string bookType, params  string[] includeList);
        List<BType> GetByBookName(string bookName, params string[] includeList);
        List<BType> GetByBook(int bookID, params string[] includeList);
        BType GetByID(int bookTypeID, params  string[] includeList);
    }
}
