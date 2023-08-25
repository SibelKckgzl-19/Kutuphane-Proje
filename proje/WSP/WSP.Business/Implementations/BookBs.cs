using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WSP.Business.CustomExceptions;
using WSP.Business.Interfaces;
using WSP.DataAccess.Implementations.EF.Repositories;
using WSP.DataAccess.Interfaces;
using WSP.Model.Dtos.Book;
using WSP.Model.Entities;

namespace WSP.Business.Implementations
{
    public class BookBs : IBookBs
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookBs(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ApiResponse<BookGetDto> GetByID(int bookID, params string[] includeList)
        {
            try
            {
                if (bookID <= 0)
                {
                    return ApiResponse<BookGetDto>.Fail(StatusCodes.Status400BadRequest, "id değeri O dan büyük olmalıdır");
                }

                var book = _repo.GetByID(bookID, includeList);
                if (book == null)
                    return ApiResponse<BookGetDto>.Fail(StatusCodes.Status404NotFound, "Bu İd li ürün bulunamadı");

                var dto = _mapper.Map<BookGetDto>(book);
                return ApiResponse<BookGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            catch (Exception)
            {
                return ApiResponse<BookGetDto>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticisine danışınız");
            }

        }

        public ApiResponse<List<BookGetDto>> GetBooks(params string[] includeList)
        {
            try
            {
                var books = _repo.GetAll(includeList: includeList);
                if (books.Count > 0)
                {
                    var returnList = _mapper.Map<List<BookGetDto>>(books);
                    return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
                }
                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunmadı");
            }
            catch (Exception)
            {
                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticisine danışınız");
            }

        }

        public ApiResponse<List<BookGetDto>> GetBooksByAuthor(string author, params string[] includeList)
        { 
            var books = _repo.GetByAuthor(author, includeList);
            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);
                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");

        }

        public ApiResponse<List<BookGetDto>> GetBooksByBookName(string bookName, params string[] includeList)
        {
            var books = _repo.GetByBookName(bookName, includeList);
            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);
                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");
        }

        public ApiResponse<List<BookGetDto>> GetBooksByPrice(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status400BadRequest, "minimum değer maksimum değerden büyük olamaz");
            if (min < 0 || max < 0)
                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status400BadRequest, "fiyatlar pozitif değer olmalıdır");
            
            var books = _repo.GetByPrice(min, max, includeList);
            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);
                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK,returnList);
            }
            return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulunamadı");

        }

        public ApiResponse<List<BookGetDto>> GetBooksByPublisher(int publisherID, params string[] includeList)
        {
            if (publisherID <= 0)

                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status400BadRequest, "İd değeri 0 dan büyük olmalıdır");

            var books = _repo.GetByPublisher(publisherID, includeList);

            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);
                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status404NotFound, "kaynak bulumamadı");

        }

        public ApiResponse<Book> Insert(BookPostDto dto)
        {
            {
                if (dto.BookName.Length < 2)
                    return ApiResponse<Book>.Fail(StatusCodes.Status400BadRequest, "kitap adı en az 2 karakterden oluşmalıdır");
                if (dto.Price <= 0)
                    return ApiResponse<Book>.Fail(StatusCodes.Status400BadRequest, "Fiyat 0 ın altında olmamalıdır");

                var entity = _mapper.Map<Book>(dto);
                var insertedBook = _repo.Insert(entity);
                return ApiResponse<Book>.Success(StatusCodes.Status201Created, insertedBook);
            }
        }

        public ApiResponse<NoData> Update(BookPutDto dto)
        {
            try
            {
                if (dto.BookID <= 0)
                {
                    throw new BadRequestException("id pozitif olmalıdır");
                }
                if (dto.BookName.Length < 2)
                {
                    throw new BadRequestException("kitap adı en az 2 karakterden oluşmalıdır");
                }
                if (dto.Author.Length < 2)
                {
                    throw new BadRequestException("yazar adı en az 2 karakterden oluşmalıdır");
                }
                if (dto.Price <= 0)
                {
                    throw new BadRequestException("kitap fiyatı pozitif olmalıdır");
                }

                var entity = _mapper.Map<Book>(dto);
                _repo.Update(entity);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }

            catch (Exception ex)
            {
                if (ex is BadRequestException)
                    return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, ex.Message);
                return ApiResponse<NoData>.Fail(StatusCodes.Status500InternalServerError, "Bir hata oluştu lütfen sistem yöneticisine danışınız");
            }

        }

        public ApiResponse<NoData> Delete(int id)
        {
            if (id <= 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "İd değeri pozitif olmalıdır");
            var entity = _repo.GetByID(id);
            _repo.Delete(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
