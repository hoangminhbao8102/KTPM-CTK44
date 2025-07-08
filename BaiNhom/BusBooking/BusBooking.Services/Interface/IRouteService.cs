using BusBooking.Core.Entities;

namespace BusBooking.Services.Interface
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Route> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Route route, CancellationToken cancellationToken = default);
        Task UpdateAsync(Route route, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
