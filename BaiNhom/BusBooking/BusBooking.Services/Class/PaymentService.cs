using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;
using BusBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Services.Class
{
    public class PaymentService : IPaymentService
    {
        private readonly BusDbContext _context;

        public PaymentService(BusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Payments
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Schedule)
                .ToListAsync(cancellationToken);
        }

        public async Task<Payment> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Payments
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Schedule)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task AddAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
