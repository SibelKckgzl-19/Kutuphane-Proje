using Infrastructure.Utilities.ApiResponses;
using PROJE.Model.Dtos;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Dtos.Category;
using PROJE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE.Business.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescriptionAsync(string desc, params string[] includeList);

        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList);

        Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
