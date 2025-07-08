using BusBooking.Core.Entities;
using BusBooking.Services.Fake;
using BusBooking.WebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public async Task BUS_TC_001_Login_WithValidAccount_ShouldRedirectToHome()
        {
            // Arrange
            var fakeService = new FakeCustomerService(new[]
            {
                new Customer { Id = 1, Email = "user@gmail.com", Password = "123456" }
            });

            var controller = new AccountController(fakeService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            controller.HttpContext.Session = new TestSession();

            // Act
            var result = await controller.Login("user@gmail.com", "123456");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirect.ActionName);
            Assert.AreEqual("Home", redirect.ControllerName);
        }

        [TestMethod]
        public async Task BUS_TC_001_Login_WithInvalidAccount_ShouldReturnViewWithError()
        {
            // Arrange
            var customers = new List<Customer>(); // Không có khách hàng
            var fakeService = new FakeCustomerService(customers);
            var controller = new AccountController(fakeService);

            // Act
            var result = await controller.Login("wrong@gmail.com", "wrongpass");

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsTrue(viewResult.ViewData.ContainsKey("Error"));
            Assert.IsNotNull(viewResult.ViewData["Error"]);
        }
    }
}
