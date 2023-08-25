using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using PROJE.Business.CustomExceptions;
using PROJE.Business.Interfaces;
using PROJE.DataAccess.Interfaces;
using PROJE.Model.Dtos.Book;
using PROJE.Model.Entities;

namespace PROJE.Business.Implementations
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

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Id Pozitif Bir Değer Olmalıdır");


            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<BookGetDto>>> GetBooksAsync(params string[] includeList)
        {

            var books = await _repo.GetAllAsync(x => x.IsActive == true, includeList: includeList);

            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);

                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("Kaynak Bulunamadı");

        }

        public async Task<ApiResponse<List<BookGetDto>>> GetBooksByAuthorAsync(string author, params string[] includeList)
        {
            if (author.Length < 2)
                throw new BadRequestException("Yazar Adı En Az 2 Karakterden Oluşmalıdır");

            if (author == null)
                throw new BadRequestException("Yazar Boş Geçilemez.");

            var books =await _repo.GetByAuthorAsync(author, includeList);

            if (books.Count > 0)
            {
                var returnList =  _mapper.Map<List<BookGetDto>>(books);

                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("Kaynak Bulunamadı");
        }

        public async Task<ApiResponse<List<BookGetDto>>> GetBooksByCategoryAsync(int categoryId, params string[] includeList)
        {
            if (categoryId <= 0)
                return ApiResponse<List<BookGetDto>>.Fail(StatusCodes.Status400BadRequest, "Id Değeri 0 dan Büyük Bir Değer Olmalıdır");

            var books = await _repo.GetByCategoryAsync(categoryId, includeList);

            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);

                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("Kaynak Bulunamadı");
        }

        public async Task<ApiResponse<List<BookGetDto>>> GetBooksByPriceAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("Min Değer Max Değerden Büyük Olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("Fiyatlar Pozitif Değer Olmalıdır");

            var books = await _repo.GetByPriceAsync(min, max, includeList);

            if (books.Count > 0)
            {
                var returnList = _mapper.Map<List<BookGetDto>>(books);

                return ApiResponse<List<BookGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("Kaynak Bulunamadı");
        }

        public async Task<ApiResponse<BookGetDto>> GetByIdAsync(int bookId, params string[] includeList)
        {

            if (bookId <= 0)
                throw new BadRequestException("Id Değeri 0 dan Büyük Bir Değer Olmalıdır");

            var book = await _repo.GetByIdAsync(bookId, includeList);

            if (book == null)
                throw new NotFoundException("Bu Kitap Bulunamadı");

            var dto = _mapper.Map<BookGetDto>(book);

            return ApiResponse<BookGetDto>.Success(StatusCodes.Status200OK, dto);

        }
    

        public async Task<ApiResponse<Book>> InsertAsync(BookPostDto dto)
        {
            if (dto.BookName == null)
                throw new BadRequestException("Kitap Adı Boş Bırakılamaz.");
            
            if (dto.BookName.Length < 2)
            throw new BadRequestException("Kitap Adı En Az 2 Karakterden Oluşmalıdır");

            if (dto.Author == null)
                throw new BadRequestException("Yazar Adı Boş Bırakılamaz.");

            if (dto.Price == null)
                throw new BadRequestException("fiyat Boş Bırakılamaz.");

            if (dto.Price <= 0)
            throw new BadRequestException("Kitap Fiyatı Pozitif Bir Değer Olmalıdır");


            var entity = _mapper.Map<Book>(dto);
            entity.IsActive = true;
            var insertedBook = await _repo.InsertAsync(entity);

            return ApiResponse<Book>.Success(StatusCodes.Status201Created, insertedBook);

        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BookPutDto dto)
        {
            if (dto.BookId <= 0)

                throw new BadRequestException("Id Pozitif Bir Değer Olmalıdır");


            if (dto.BookName.Length < 2)

                throw new BadRequestException("Kitap Adı En Az 2 Karakterden Oluşmalıdır");

            if (dto.Price <= 0)
                throw new BadRequestException("Kitap Fiyatı Pozitif Bir Değer Olmalıdır");


            var entity = _mapper.Map<Book>(dto);
            entity.IsActive = true;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);


    }

    }
}
