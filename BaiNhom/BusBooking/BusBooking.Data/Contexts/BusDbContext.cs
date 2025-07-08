using BusBooking.Core.Entities;
using BusBooking.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Data.Contexts
{
    public class BusDbContext : DbContext
    {
        public BusDbContext(DbContextOptions<BusDbContext> options)
            : base(options)
        {
        }

        // DbSet đại diện cho các bảng
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ánh xạ bằng Fluent API
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new RouteMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
