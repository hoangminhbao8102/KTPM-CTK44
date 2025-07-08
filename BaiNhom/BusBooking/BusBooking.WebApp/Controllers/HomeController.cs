using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Trang chủ";
            return View();
        }
    }
}
