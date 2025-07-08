using BusBooking.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.WebApp.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task<IActionResult> Index()
        {
            var routes = await _routeService.GetAllAsync();
            return View(routes);
        }
    }
}
