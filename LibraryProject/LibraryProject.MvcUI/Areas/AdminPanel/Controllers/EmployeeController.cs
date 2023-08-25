using LibraryProject.MvcUI.ApiServices;
using LibraryProject.MvcUI.Areas.AdminPanel.Filters;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Category;
using LibraryProject.MvcUI.Areas.AdminPanel.Models.Dtos.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class EmployeeController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;

        public EmployeeController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetData<ResponseBody<List<EmployeeItem>>>("/employees");

            return View(response.Data);
        }

        public async Task<IActionResult> Save(NewEmployeeDto dto, IFormFile employeeImage, string name, string country, string city, DateTime birthDate)
        {
            if (name == null)
                return Json(new { IsSuccess = false, Message = "Personel adı girilmelidir." });

            if (country == null)
                return Json(new { IsSuccess = false, Message = "Ülke girilmelidir." });

            if (city == null)
                return Json(new { IsSuccess = false, Message = "Şehir girilmelidir." });

            if (birthDate == null)
                return Json(new { IsSuccess = false, Message = "doğum günü girilmelidir." });

            if (employeeImage == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir." });

            if (!employeeImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Sadece resim dosyası seçilebilir." });

            if (employeeImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Dosya büyüklüğü en fazla 250 KB olabilir." });


            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(employeeImage.FileName)}";

            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/employeeImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await employeeImage.CopyToAsync(fs);
            }

            var postData = new
            {
                Name = dto.Name,
                Country = dto.Country,
                City = dto.City,
                BirthDate = dto.BirthDate,
                PicturePath = $@"/adminPanel/employeeImages/{randomFileName}",
            };

            var response = await _apiService.PostData<ResponseBody<EmployeeItem>>("/Employees", JsonSerializer.Serialize(postData));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Personel başarıyla kaydedildi" });

            var errorMessage = string.Empty;
            foreach (var item in response.ErrorMessages)
            {
                errorMessage += item + "<br/>";
            }
            return Json(new
            {
                IsSuccess = false,
                Message = $"Personel Kaydedilemedi. <br/> {errorMessage}"
            });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteData($"/employees/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Personel Silindi" });

            return Json(new { IsSuccess = false, Message = "Personel Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response = await _apiService.GetData<ResponseBody<EmployeeItem>>($"/Employees/{id}");

            return Json(new
            {
                Name = response.Data.Name,
                Country = response.Data.Country,
                City = response.Data.City,
                BirthDate = response.Data.BirthDate,
                PicturePath = response.Data.PicturePath,
                EmployeeID = response.Data.EmployeeID
            });
        }



    }

    }
