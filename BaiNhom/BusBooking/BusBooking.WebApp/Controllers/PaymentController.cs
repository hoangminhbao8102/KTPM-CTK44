using BusBooking.Core.Entities;
using BusBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ITicketService _ticketService;

        public PaymentController(IPaymentService paymentService, ITicketService ticketService)
        {
            _paymentService = paymentService;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> Pay(int ticketId)
        {
            var ticket = await _ticketService.GetByIdAsync(ticketId);
            if (ticket == null || ticket.Status != "DaDat")
                return NotFound();

            var payment = new Payment
            {
                TicketId = ticketId,
                PaymentDate = DateTime.Now,
                Method = "ATM",
                Amount = ticket.Quantity * ticket.Schedule.TicketPrice
            };

            await _paymentService.AddAsync(payment);

            ticket.Status = "Đã thanh toán";
            await _ticketService.UpdateAsync(ticket);

            return RedirectToAction("History", "Ticket");
        }
    }
}
