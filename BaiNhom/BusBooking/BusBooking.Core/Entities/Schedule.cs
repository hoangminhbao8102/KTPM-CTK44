using BusBooking.Core.Contracts;

namespace BusBooking.Core.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public DateTime DepartureDate { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public decimal TicketPrice { get; set; }

        public int SeatCount { get; set; }
    }
}
