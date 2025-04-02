using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBookingSystemApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingSystemApp.Domain.Constant;
namespace TicketBookingSystemApp.Infrastructure.Configuration
{
    public class EventSeedConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData
            (
                new Event
                {
                    EventId = 1, // Required for seeding, but auto-incremented during runtime
                    EventName = "Tech Conference 2025",
                    Description = "A premier technology conference featuring industry experts and innovations.",
                    Date = new DateTime(2025, 6, 15, 10, 0, 0), // Fixed date to avoid 'DateTime.Now' issues
                    Venue = "Convention Center, Mumbai",
                    AvailableSeats = 500,
                    Price = 2999,
                    EventType = EventType.Conference
                },
                new Event
                {
                    EventId = 2,
                    EventName = "Music Fest 2025",
                    Description = "A grand music festival featuring top artists.",
                    Date = new DateTime(2025, 7, 20, 18, 0, 0),
                    Venue = "Stadium, Delhi",
                    AvailableSeats = 1000,
                    Price = 1999,
                    EventType = EventType.Concert
                }
            );
        }
    }
}
