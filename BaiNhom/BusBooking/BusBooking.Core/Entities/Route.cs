using BusBooking.Core.Contracts;

namespace BusBooking.Core.Entities
{
    public class Route : IEntity
    {
        public int Id { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }
    }
}
