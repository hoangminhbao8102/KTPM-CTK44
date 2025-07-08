using BusBooking.Core.Entities;
using BusBooking.Services.Interface;

namespace BusBooking.Services.Fake
{
    public class FakeScheduleService : IScheduleService
    {
        private readonly List<Schedule> _schedules;

        public FakeScheduleService(IEnumerable<Schedule> initialSchedules = null)
        {
            _schedules = initialSchedules?.ToList() ?? new List<Schedule>();
        }

        public Task<IEnumerable<Schedule>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Schedule>>(_schedules);
        }

        public Task<Schedule> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var schedule = _schedules.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(schedule);
        }

        public Task AddAsync(Schedule schedule, CancellationToken cancellationToken = default)
        {
            if (schedule.Id == 0)
            {
                schedule.Id = _schedules.Count > 0 ? _schedules.Max(s => s.Id) + 1 : 1;
            }
            _schedules.Add(schedule);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Schedule schedule, CancellationToken cancellationToken = default)
        {
            var existing = _schedules.FirstOrDefault(s => s.Id == schedule.Id);
            if (existing != null)
            {
                existing.DepartureDate = schedule.DepartureDate;
                existing.Route = schedule.Route;
                existing.SeatCount = schedule.SeatCount;
                existing.TicketPrice = schedule.TicketPrice;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var schedule = _schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
            {
                _schedules.Remove(schedule);
            }
            return Task.CompletedTask;
        }
    }
}
