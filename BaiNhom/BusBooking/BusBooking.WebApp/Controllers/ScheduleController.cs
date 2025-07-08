using BusBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Search(int routeId, DateTime? date)
        {
            var schedules = await _scheduleService.GetAllAsync();
            var result = schedules.Where(s => s.RouteId == routeId);

            if (date.HasValue)
            {
                result = result.Where(s => s.DepartureDate.Date == date.Value.Date);
            }

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var schedule = await _scheduleService.GetByIdAsync(id);
            if (schedule == null)
                return NotFound();

            return View(schedule);
        }
    }
}
