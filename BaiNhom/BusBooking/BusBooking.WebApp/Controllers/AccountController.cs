using BusBooking.Core.Entities;
using BusBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;

        public AccountController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var customer = await _customerService.AuthenticateAsync(email, password);
            if (customer != null)
            {
                // Giả lập lưu thông tin đăng nhập (bạn có thể dùng Identity hoặc Session)
                HttpContext.Session.SetString("CustomerEmail", customer.Email);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Email hoặc mật khẩu không đúng";
            return View();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Customer model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddAsync(model);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerEmail");
            return RedirectToAction("Login");
        }
    }
}
