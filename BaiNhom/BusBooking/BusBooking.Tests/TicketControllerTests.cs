using BusBooking.Core.Entities;
using BusBooking.Services.Fake;
using BusBooking.WebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Tests
{
    [TestClass]
    public class TicketControllerTests
    {
        [TestMethod]
        public async Task BUS_TC_004_Book_ShouldAddTicketAndRedirectToHistory()
        {
            // Arrange
            var schedule = new Schedule
            {
                Id = 1,
                TicketPrice = 300000,
                Route = new Route { Departure = "Hà Nội", Destination = "Đà Nẵng" }
            };

            var fakeTicketService = new FakeTicketService(new[]
            {
                new Ticket { Id = 2, Customer = new Customer { Email = "user@gmail.com" } }
            });
            var fakeScheduleService = new FakeScheduleService(new[] { schedule });

            var controller = new TicketController(fakeTicketService, fakeScheduleService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            controller.HttpContext.Session = new TestSession();
            controller.HttpContext.Session.SetString("CustomerEmail", "user@gmail.com");

            // Act
            var result = await controller.Book(1, 2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = result as RedirectToActionResult;
            Assert.AreEqual("History", redirect.ActionName);

            Assert.AreEqual(1, fakeTicketService.AddedTickets.Count);
            var addedTicket = fakeTicketService.AddedTickets[0];
            Assert.AreEqual(2, addedTicket.Quantity);
            Assert.AreEqual(1, addedTicket.ScheduleId);
        }

        [TestMethod]
        public async Task BUS_TC_005_History_ShouldReturnTickets()
        {
            // Arrange
            var fakeService = new FakeTicketService(new[]
            {
                new Ticket { Id = 1, Customer = new Customer { Email = "user@gmail.com" } }
            });

            var controller = new TicketController(fakeService, null);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            controller.HttpContext.Session = new TestSession();
            controller.HttpContext.Session.SetString("CustomerEmail", "user@gmail.com");

            // Act
            var result = await controller.History() as ViewResult;
            var model = result.Model as IEnumerable<Ticket>;

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count());
        }

        [TestMethod]
        public async Task BUS_TC_006_Cancel_ShouldUpdateTicketStatus()
        {
            // Arrange
            var ticket = new Ticket { Id = 1, Status = "Đã đặt" };
            var fakeService = new FakeTicketService(new[] { ticket });

            var controller = new TicketController(fakeService, null);

            // Act
            var result = await controller.Cancel(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(1, fakeService.UpdatedTickets.Count);
            var updated = fakeService.UpdatedTickets[0];
            Assert.AreEqual("Đã hủy", updated.Status);
        }
    }
}
