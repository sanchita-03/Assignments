using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using TicketBookingSystemApp.Domain;
using TicketBookingSystemApp.Domain.Constant;

namespace TicketBookingSystemApp.Infrastructure.Configuration
{
    public class BookingSeedConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.SeatNumber)
                 .HasConversion(
                     v => string.Join(",", v),
                     v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                 );

            builder.HasData(
                new Booking
                {
                    BookingId = 1,
                    UserId = 1,
                    EventId = 1,
                    SeatNumber = new List<int> { 10, 11, 12 },
                    BookingDate = DateTime.UtcNow,
                    Status = Status.Confirmed
                });
        }
    }
}
