using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Services.Class
{
    public class CustomerService : ICustomerService
    {
        private readonly BusDbContext _context;

        public CustomerService(BusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FindAsync(id, cancellationToken);
        }

        public async Task<Customer> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email && c.Password == password, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }   

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
