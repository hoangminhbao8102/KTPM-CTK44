using BusBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusBooking.Data.Mappings
{
    public class RouteMap : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Departure)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Destination)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
