using BusBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusBooking.Data.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DepartureDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DepartureTime)
                .IsRequired()
                .HasColumnType("time");

            builder.Property(x => x.TicketPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SeatCount)
                .IsRequired();

            builder.HasOne(x => x.Route)
                .WithMany()
                .HasForeignKey(x => x.RouteId);
        }
    }
}
