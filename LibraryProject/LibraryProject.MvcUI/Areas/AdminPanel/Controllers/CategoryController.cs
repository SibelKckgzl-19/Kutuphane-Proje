using LibraryProject.MvcUI.ApiServices;
using LibraryProject.MvcUI.Areas.AdminPanel.Filters;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class CategoryController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;

        public CategoryController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            
            var jsonTokenData = HttpContext.Session.GetString("AccessToken");
            var jwt = JsonSerializer.Deserialize<AccessTokenItem>(jsonTokenData); 

            var response =await  _apiService.GetData<ResponseBody<List<CategoryItem>>>("/Categories",jwt.Token);
        
            return View(response.Data);
        }

        public async Task<IActionResult> Save(NewCategoryDto dto,IFormFile categoryImage, string categoryName, string description)
        {
            if (categoryName == null)
                return Json(new { IsSuccess = false, Message = "Kategori adı girilmelidir." });

            if (description == null)
                return Json(new { IsSuccess = false, Message = "Açıklama girilmelidir." });

            if (categoryImage == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir." });

            if (!categoryImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilebilir." });

            if (categoryImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 250 KB olabilir." });

            
            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(categoryImage.FileName)}";
            
            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/categoryImages/{randomFileName}";
            
            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await categoryImage.CopyToAsync(fs);
            }

            var postData = new
            {
                CategoryName = dto.CategoryName,  
                Description = dto.Description,
                PicturePath = $@"/adminPanel/categoryImages/{randomFileName}",
            };

            var response = await _apiService.PostData<ResponseBody<CategoryItem>>("/Categories", JsonSerializer.Serialize(postData));

            if (response.StatusCode ==201)
                return Json(new { IsSuccess = true, Message = "Kategori başarıyla kaydedildi" });

            var errorMessage = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessage += item + "<br/>";
            }
            return Json(new
            {
                IsSuccess = false,
                Message = $"Kategori Kaydedilemedi. <br/> {errorMessage}"
            });
         
                    
        }
        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            var response = await _apiService.DeleteData($"/categories/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Kategori Silindi" });

            return Json(new { IsSuccess = false, Message = "Kategori Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _apiService.GetData<ResponseBody<CategoryItem>>($"/Categories/{id}");

            return Json(new 
            {
                CategoryName = response.Data.CategoryName,
                Description = response.Data.Description,
                PicturePath = response.Data.PicturePath,
                CategoryId = response.Data.CategoryId
            });
        }



    }
}
