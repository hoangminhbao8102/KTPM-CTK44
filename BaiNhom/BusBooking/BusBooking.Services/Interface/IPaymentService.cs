using BusBooking.Core.Entities;

namespace BusBooking.Services.Interface
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Payment> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Payment payment, CancellationToken cancellationToken = default);
    }
}
