using LibraryProject.MvcUI.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LibraryProject.MvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class HomeController : Controller
    {
        [LogAspect]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
