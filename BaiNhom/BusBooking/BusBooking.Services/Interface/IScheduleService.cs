using BusBooking.Core.Entities;

namespace BusBooking.Services.Interface
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Schedule> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Schedule schedule, CancellationToken cancellationToken = default);
        Task UpdateAsync(Schedule schedule, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
