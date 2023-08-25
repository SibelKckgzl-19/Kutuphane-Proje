using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WSP.Business.CustomExceptions;
using WSP.Business.Interfaces;
using WSP.DataAccess.Interfaces;
using WSP.Model.Dtos.BType;
using WSP.Model.Entities;

namespace WSP.Business.Implementations
{
    public class BTypeBs : IBTypeBs
    {
        private readonly IBTypeRepository _repo;
        private readonly IMapper _mapper;

        public BTypeBs(IBTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public ApiResponse<NoData> Delete(int id)
        {
            if (id == 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "id değeri pozitif olmalıdır");
            var entity = _repo.GetByID(id);
            _repo.Delete(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public ApiResponse<List<BTypeGetDto>> GetBTypes(params string[] includeList)
        {
            try
            {
                var bTypes = _repo.GetAll(includeList: includeList);
                if (bTypes.Count > 0)
                {
                    var returnList = _mapper.Map<List<BTypeGetDto>>(bTypes);
                    return ApiResponse<List<BTypeGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }
                return ApiResponse<List<BTypeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");

            }
            catch (Exception)
            {
                return ApiResponse<List<BTypeGetDto>>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticinize danışınız");
            }
        }

        public ApiResponse<List<BTypeGetDto>> GetBTypesByBookName(string bookName, params string[] includeList)
        {
            var bTypes = _repo.GetByBookName(bookName, includeList);
            if (bTypes.Count > 0)
            {
                var returnList = _mapper.Map<List<BTypeGetDto>>(bTypes);
                return ApiResponse<List<BTypeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<BTypeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");

        }

        public ApiResponse<List<BTypeGetDto>> GetBTypesByBook(int bookID, params string[] includeList)
        {
            var bTypes = _repo.GetByBook(bookID, includeList);
            if (bTypes.Count > 0)
            {
                var returnList = _mapper.Map<List<BTypeGetDto>>(bTypes);
                return ApiResponse<List<BTypeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<BTypeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");
        }

        public ApiResponse<BTypeGetDto> GetByID(int bookTypeID, params string[] includeList)
        {
            try
            {

                if (bookTypeID <= 0)
                {
                    return ApiResponse<BTypeGetDto>.Fail(StatusCodes.Status400BadRequest, "id değeri 0 dan büyük olmalıdır");
                }
                var bTypes = _repo.GetByID(bookTypeID, includeList);

                if (bTypes == null)
                    return ApiResponse<BTypeGetDto>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");

                var dto = _mapper.Map<BTypeGetDto>(bTypes);
                return ApiResponse<BTypeGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            catch (Exception)
            {
                return ApiResponse<BTypeGetDto>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticinize danışınız");
            }
        }

        public ApiResponse<BType> Insert(BTypePostDto dto)
        {
            {
                if (dto.BookType.Length < 2)
                    return ApiResponse<BType>.Fail(StatusCodes.Status400BadRequest, "kitap türü en az 2 karakter olmalıdır");

                var entity = _mapper.Map<BType>(dto);
                var insertedBType = _repo.Insert(entity);
                return ApiResponse<BType>.Success(StatusCodes.Status201Created, insertedBType);
            }
        }

        public ApiResponse<NoData> Update(BTypePutDto dto)
        {
            try
            {
                if (dto.BookTypeID <= 0)
                {
                    throw new BadRequestException("id pozitif olmalıdır");
                }
                if (dto.BookType.Length < 2)
                {
                    throw new BadRequestException("kitap türü en az 2 karakter olmalıdır");
                }

                var entity = _mapper.Map<BType>(dto);
                _repo.Update(entity);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, ex.Message);

                return ApiResponse<NoData>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticinize danışınız");
            }

        }

        public ApiResponse<List<BTypeGetDto>> GetBTypesByBookType(string bookType, params string[] includeList)
        {
            var bTypes = _repo.GetByBookType(bookType, includeList);
            if (bTypes.Count > 0)
            {
                var returnList = _mapper.Map<List<BTypeGetDto>>(bTypes);
                return ApiResponse<List<BTypeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<BTypeGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");
        }
    }
}

     

       

  