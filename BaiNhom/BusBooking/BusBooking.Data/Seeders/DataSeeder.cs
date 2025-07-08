using BusBooking.Core.Entities;
using BusBooking.Data.Contexts;

namespace BusBooking.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BusDbContext _dbContext;

        public DataSeeder(BusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Routes.Any())
            {
                return; // Đã có dữ liệu, không seed nữa
            }

            var customers = AddCustomers();
            var routes = AddRoutes();
            var schedules = AddSchedules(routes);
            var tickets = AddTickets(customers, schedules);
            var payments = AddPayments(tickets);
        }

        private IList<Customer> AddCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { FullName = "Nguyễn Văn A", Email = "a@gmail.com", Password = "123456", Phone = "0901234567" },
                new Customer { FullName = "Trần Thị B", Email = "b@gmail.com", Password = "123456", Phone = "0912345678" }
            };

            _dbContext.AddRange(customers);
            _dbContext.SaveChanges();

            return customers;
        }

        private IList<Route> AddRoutes()
        {
            var routes = new List<Route>
            {
                new Route { Departure = "Hà Nội", Destination = "Đà Nẵng" },
                new Route { Departure = "Hồ Chí Minh", Destination = "Nha Trang" }
            };

            _dbContext.AddRange(routes);
            _dbContext.SaveChanges();

            return routes;
        }

        private IList<Schedule> AddSchedules(IList<Route> routes)
        {
            var schedules = new List<Schedule>
            {
                new Schedule
                {
                    RouteId = routes[0].Id,
                    DepartureDate = DateTime.Today.AddDays(1),
                    DepartureTime = new TimeSpan(8, 0, 0),
                    TicketPrice = 300000,
                    SeatCount = 40
                },
                new Schedule
                {
                    RouteId = routes[1].Id,
                    DepartureDate = DateTime.Today.AddDays(2),
                    DepartureTime = new TimeSpan(9, 0, 0),
                    TicketPrice = 250000,
                    SeatCount = 35
                }
            };

            _dbContext.AddRange(schedules);
            _dbContext.SaveChanges();

            return schedules;
        }

        private IList<Ticket> AddTickets(IList<Customer> customers, IList<Schedule> schedules)
        {
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    CustomerId = customers[0].Id,
                    ScheduleId = schedules[0].Id,
                    Quantity = 2,
                    Status = "Đã đặt"
                },
                new Ticket
                {
                    CustomerId = customers[1].Id,
                    ScheduleId = schedules[1].Id,
                    Quantity = 1,
                    Status = "Đã thanh toán"
                }
            };

            _dbContext.AddRange(tickets);
            _dbContext.SaveChanges();

            return tickets;
        }

        private IList<Payment> AddPayments(IList<Ticket> tickets)
        {
            var payments = new List<Payment>
            {
                new Payment
                {
                    TicketId = tickets[1].Id,
                    PaymentDate = DateTime.Now,
                    Method = "ATM",
                    Amount = tickets[1].Quantity * tickets[1].Schedule.TicketPrice
                }
            };

            _dbContext.AddRange(payments);
            _dbContext.SaveChanges();

            return payments;
        }
    }
}
