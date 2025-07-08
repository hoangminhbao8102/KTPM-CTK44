using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Services.Class
{
    public class RouteService : IRouteService
    {
        private readonly BusDbContext _context;

        public RouteService(BusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Route>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Routes.ToListAsync(cancellationToken);
        }

        public async Task<Route> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Routes.FindAsync(id, cancellationToken);
        }

        public async Task AddAsync(Route route, CancellationToken cancellationToken = default)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Route route, CancellationToken cancellationToken = default)
        {
            _context.Routes.Update(route);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var route = await GetByIdAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
