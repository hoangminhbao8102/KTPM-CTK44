using BusBooking.Core.Entities;

namespace BusBooking.Services.Interface
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Ticket> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default);
        Task UpdateAsync(Ticket ticket, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
