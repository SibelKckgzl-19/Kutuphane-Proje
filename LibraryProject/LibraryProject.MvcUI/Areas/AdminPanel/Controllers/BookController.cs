using LibraryProject.MvcUI.ApiServices;
using LibraryProject.MvcUI.Areas.AdminPanel.Filters;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Book;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class BookController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;

        public BookController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetData<ResponseBody<List<BookItem>>>("/books");

            return View(response.Data);
        }

        public async Task<IActionResult> Save(NewBookDto dto, IFormFile bookImage, string bookName, string author, string categoryName, string price)
        {
            if (bookName == null)
                return Json(new { IsSuccess = false, Message = "Kitap adı girilmelidir." });

            if (bookName.Length < 2)
                return Json(new { IsSuccess = false, Message = "Kitap adı en az 2 karakter olmalıdır." });

            if (author == null)
                return Json(new { IsSuccess = false, Message = "Yazar adı girilmelidir." });

            if (categoryName == null)
                return Json(new { IsSuccess = false, Message = "Kategori adı girilmelidir." });

            if (price == null)
                return Json(new { IsSuccess = false, Message = "Fiyat girilmelidir." });

            if (bookImage == null)
                return Json(new { IsSuccess = false, Message = "Kitap resmi seçilmelidir." });

            if (!bookImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilebilir." });

            if (bookImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 250 KB olabilir." });


            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(bookImage.FileName)}";

            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/bookImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await bookImage.CopyToAsync(fs);
            }

            var postData = new
            {
                BookName = dto.BookName,
                Author = dto.Author,
                CategoryName = dto.CategoryName,
                Price = dto.Price,
                PicturePath = $@"/adminPanel/bookImages/{randomFileName}",
            };

            var response = await _apiService.PostData<ResponseBody<BookItem>>("/books", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Yeni Kitap başarıyla kaydedildi" });

            var errorMessage = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessage += item + "<br/>";
            }
            return Json(new
            {
                IsSuccess = false,
                Message = $"Yeni Kitap Kaydedilemedi. <br/> {errorMessage}"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteData($"/books/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Kitap Silindi" });

            return Json(new { IsSuccess = false, Message = "Kitap Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _apiService.GetData<ResponseBody<BookItem>>($"/Books/{id}");

            return Json(new
            {
                BookName = response.Data.BookName,
                Author = response.Data.Author,
                CategoryName = response.Data.CategoryName,
                Price = response.Data.Price,
                PicturePath = response.Data.PicturePath,
                BookId = response.Data.BookId
            });
        }


    }
}
