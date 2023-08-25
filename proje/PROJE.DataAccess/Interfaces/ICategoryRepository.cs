using Infrastructure.DataAccess;
using PROJE.Model.Entities;

namespace PROJE.DataAccess.Interfaces
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<List<Category>> GetByDescAsync (string desc, params string[] includeList);

        Task<Category> GetByIdAsync (int categoryId, params string[] includeList);
    
        Task<bool> IsCategoryExistWithName(string categoryName);
    }
}
