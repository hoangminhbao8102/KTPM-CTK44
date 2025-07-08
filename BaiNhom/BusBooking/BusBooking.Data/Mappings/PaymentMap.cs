using BusBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusBooking.Data.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("THANH_TOAN");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PaymentDate)
                .IsRequired();

            builder.Property(x => x.Method)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Ticket)
                .WithMany()
                .HasForeignKey(x => x.TicketId);
        }
    }
}
