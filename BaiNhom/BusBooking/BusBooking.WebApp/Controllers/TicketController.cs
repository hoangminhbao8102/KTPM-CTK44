using BusBooking.Core.Entities;
using BusBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IScheduleService _scheduleService;

        public TicketController(ITicketService ticketService, IScheduleService scheduleService)
        {
            _ticketService = ticketService;
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> Book(int scheduleId)
        {
            var schedule = await _scheduleService.GetByIdAsync(scheduleId);
            if (schedule == null)
                return NotFound();

            ViewBag.Schedule = schedule;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Book(int scheduleId, int soLuong)
        {
            var customerEmail = HttpContext.Session.GetString("CustomerEmail");
            if (string.IsNullOrEmpty(customerEmail))
                return RedirectToAction("Login", "Account");

            var ticket = new Ticket
            {
                Schedule = await _scheduleService.GetByIdAsync(scheduleId),
                ScheduleId = scheduleId,
                Quantity = soLuong,
                Status = "Đã đặt",
                CustomerId = (await _ticketService.GetAllAsync())
                    .FirstOrDefault(t => t.Customer.Email == customerEmail)?.CustomerId ?? 0
            };

            await _ticketService.AddAsync(ticket);
            return RedirectToAction("History");
        }

        public async Task<IActionResult> History()
        {
            var customerEmail = HttpContext.Session.GetString("CustomerEmail");
            if (string.IsNullOrEmpty(customerEmail))
                return RedirectToAction("Login", "Account");

            var tickets = await _ticketService.GetAllAsync();
            var result = tickets.Where(t => t.Customer.Email == customerEmail);
            return View(result);
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
                return NotFound();

            ticket.Status = "Đã hủy";
            await _ticketService.UpdateAsync(ticket);

            return RedirectToAction("History");
        }
    }
}
