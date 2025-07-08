using BusBooking.Core.Contracts;

namespace BusBooking.Core.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Method { get; set; }

        public decimal Amount { get; set; }
    }
}
