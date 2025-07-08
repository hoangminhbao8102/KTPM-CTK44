using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Services.Class
{
    public class ScheduleService : IScheduleService
    {
        private readonly BusDbContext _context;

        public ScheduleService(BusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Schedules
                .Include(s => s.Route)
                .ToListAsync(cancellationToken);
        }

        public async Task<Schedule> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules
                .Include(s => s.Route)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task AddAsync(Schedule schedule, CancellationToken cancellationToken = default)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Schedule schedule, CancellationToken cancellationToken = default)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var schedule = await GetByIdAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
