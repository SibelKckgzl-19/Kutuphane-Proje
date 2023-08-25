using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using PROJE.Business.CustomExceptions;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Dtos.Category;
using PROJE.Model.Entities;

namespace PROJE.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryBs(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Id Pozitif Bir Değer Olmalıdır.");

            var entity =await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList)
        {
                if (categoryId <= 0)
                throw new BadRequestException("Id değeri 0 dan büyük bir değer olmalıdır"); 

                var category = await _repo.GetByIdAsync(categoryId, includeList);

                if (category == null)
                throw new NotFoundException("Kategori boş olamaz.");

                var dto = _mapper.Map<CategoryGetDto>(category);

                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
            
                
            
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList)
        {
            
                var categories =await _repo.GetAllAsync(x => x.IsActive == true, includeList: includeList);

                if (categories.Count > 0)
                {
                    var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                    return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }

                throw new NotFoundException("Kaynak Bulunamadı.");


        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescriptionAsync(string desc, params string[] includeList)
        {
            if (desc.Length < 2)
                throw new BadRequestException("Açıklama En Az 2 Karakterden Oluşmalıdır");

            if (desc == null)
                throw new BadRequestException("Açıklama Boş Olamaz.");

            var categories = await _repo.GetByDescAsync(desc, includeList);

            if (categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);

                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status404NotFound, "Kaynak Bulunamadı");
        }

        public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto)
        {
                if (await _repo.IsCategoryExistWithName(dto.CategoryName))
                    throw new BadRequestException("Kategori Bulunmaktadır.");

                if (dto.CategoryName == null)
                    throw new BadRequestException("Kategori Adı Boş Bırakılamaz.");

                if (dto.Description == null)
                    throw new BadRequestException("Açıklama Boş Bırakılamaz.");


                var entity =  _mapper.Map<Category>(dto);
                entity.IsActive = true;
                var insertedCategory = await _repo.InsertAsync(entity);

                return ApiResponse<Category>.Success(StatusCodes.Status201Created, insertedCategory);
            
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
           
                if (dto.CategoryId <= 0)

                    throw new BadRequestException("Id Pozitif Bir Değer Olmalıdır.");
               
                if (dto.CategoryName.Length < 2)
                
                    throw new BadRequestException("Kategori adı en az 2 karakterden oluşmalıdır");
                
                
            var entity = _mapper.Map<Category>(dto);
            entity.IsActive = true;
            await _repo.UpdateAsync(entity);
            
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
        
    }
}
