using BusBooking.Core.Contracts;

namespace BusBooking.Core.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
