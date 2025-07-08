using BusBooking.Core.Entities;

namespace BusBooking.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Customer> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
