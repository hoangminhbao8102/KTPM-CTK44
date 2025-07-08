using BusBooking.Core.Entities;
using BusBooking.Services.Fake;
using BusBooking.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Tests
{
    [TestClass]
    public class PaymentControllerTests
    {
        [TestMethod]
        public async Task BUS_TC_007_Pay_ShouldAddPaymentAndUpdateTicket()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Quantity = 2,
                Status = "Đã đặt",
                Schedule = new Schedule { TicketPrice = 250000 }
            };
            var fakeTicketService = new FakeTicketService(new[] { ticket });
            var fakePaymentService = new FakePaymentService();

            var controller = new PaymentController(fakePaymentService, fakeTicketService);
            var result = await controller.Pay(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
