using BusBooking.Core.Contracts;

namespace BusBooking.Core.Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; }
    }
}
