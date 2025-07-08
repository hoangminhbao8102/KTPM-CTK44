using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Services.Class
{
    public class TicketService : ITicketService
    {
        private readonly BusDbContext _context;

        public TicketService(BusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Schedule)
                .ThenInclude(s => s.Route)
                .ToListAsync(cancellationToken);
        }

        public async Task<Ticket> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Schedule)
                .ThenInclude(s => s.Route)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var ticket = await GetByIdAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
