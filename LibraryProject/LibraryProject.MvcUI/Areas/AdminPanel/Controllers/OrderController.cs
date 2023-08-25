using LibraryProject.MvcUI.ApiServices;
using LibraryProject.MvcUI.Areas.AdminPanel.Filters;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Category;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Order;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class OrderController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;

        public OrderController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetData<ResponseBody<List<OrderItem>>>("/Orders");

            return View(response.Data);
        }

        public async Task<IActionResult> Save(NewOrderDto dto, IFormFile orderImage, string shipAddress, string shipCity, string employeeId)
        {
            if (employeeId == null)
                return Json(new { IsSuccess = false, Message = "Kategori adı girilmelidir." });

            if (shipAddress == null)
                return Json(new { IsSuccess = false, Message = "Açıklama girilmelidir." });

            if (shipCity == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir." });

            if (orderImage == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir." });

            if (!orderImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilebilir." });

            if (orderImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 250 KB olabilir." });


            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(orderImage.FileName)}";

            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/orderImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await orderImage.CopyToAsync(fs);
            }

            var postData = new
            {
                EmployeeId = dto.EmployeeId,
                ShipAddress = dto.ShipAddress,
                ShipCity = dto.ShipCity,
                PicturePath = $@"/adminPanel/orderImages/{randomFileName}",
            };

            var response = await _apiService.PostData<ResponseBody<OrderItem>>("/Orders", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Satış başarıyla kaydedildi" });

            var errorMessage = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessage += item + "<br/>";
            }
            return Json(new
            {
                IsSuccess = false,
                Message = $"Satış Kaydedilemedi. <br/> {errorMessage}"
            });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteData($"/Orders/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Kategori Silindi" });

            return Json(new { IsSuccess = false, Message = "Kategori Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder(int id)
        {
            var response = await _apiService.GetData<ResponseBody<OrderItem>>($"/Orders/{id}");

            return Json(new
            {
                EmployeeId = response.Data.EmployeeId,
                ShipAddress = response.Data.ShipAddress,
                ShipCity = response.Data.ShipCity,
                PicturePath = response.Data.PicturePath,
                OrderId = response.Data.OrderId
            });
        }

    }
}
