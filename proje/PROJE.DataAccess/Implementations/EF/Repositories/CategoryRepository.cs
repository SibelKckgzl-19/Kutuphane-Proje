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
    public class CategoryRepository : BaseRepositoryEf<Category, LibraryContext>, ICategoryRepository
    {
        public async Task<List<Category>> GetByDescAsync(string desc, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Description == desc, includeList);
        }

        public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        {
            return  await GetAsync(prd => prd.CategoryId == categoryId, includeList);
        }

        public async Task<bool> IsCategoryExistWithName(string categoryName)
        {
            var categories = await GetAllAsync(x => x.CategoryName == categoryName);
            if(categories != null && categories.Count > 0) 
                return true;
            return false;
        }
    }
}
