using BusBooking.Core.Entities;
using BusBooking.Services.Interface;

namespace BusBooking.Services.Fake
{
    public class FakeTicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();

        public List<Ticket> UpdatedTickets { get; } = new List<Ticket>();
        public List<Ticket> AddedTickets { get; } = new List<Ticket>();
        public List<int> DeletedTicketIds { get; } = new List<int>();

        /// <summary>
        /// Tạo FakeTicketService với dữ liệu ban đầu
        /// </summary>
        public FakeTicketService(IEnumerable<Ticket> initialTickets = null)
        {
            if (initialTickets != null)
            {
                _tickets.AddRange(initialTickets);
            }
        }

        public Task<IEnumerable<Ticket>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Ticket>>(_tickets);
        }

        public Task<Ticket> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(ticket);
        }

        public Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            if (ticket.Id == 0)
            {
                ticket.Id = _tickets.Count > 0 ? _tickets.Max(t => t.Id) + 1 : 1;
            }
            _tickets.Add(ticket);
            AddedTickets.Add(ticket);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            var existing = _tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (existing != null)
            {
                existing.Status = ticket.Status;
                existing.Quantity = ticket.Quantity;
                existing.Schedule = ticket.Schedule;
            }

            UpdatedTickets.Add(ticket);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
            DeletedTicketIds.Add(id);
            return Task.CompletedTask;
        }
    }
}
