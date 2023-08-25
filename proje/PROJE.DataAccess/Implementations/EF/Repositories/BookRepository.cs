using Infrastructure.DataAccess.EF;
using PROJE.DataAccess.Implementations.EF.Contexts;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.DataAccess.Implementations.EF.Repositories
{
    public class BookRepository : BaseRepositoryEf<Book, LibraryContext>, IBookRepository
    {
        

        public async Task<List<Book>> GetByAuthorAsync(string author, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Author == author, includeList);
        }


        public async Task<List<Book>> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.CategoryId == categoryId, includeList);
        }

        public async Task<Book> GetByIdAsync(int bookId, params string[] includeList)
        {
            return await GetAsync(prd => prd.BookId == bookId, includeList);
        }

        public async Task<List<Book>> GetByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Price > min && prd.Price < max, includeList);
        }
    }
}
