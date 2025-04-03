using Microsoft.EntityFrameworkCore;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;
using TicketBookingSystemApp.Infrastructure.Context;

namespace TicketBookingSystemApp.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        protected readonly TicketBookingDbContext _ticketBookingDbContext;
        public EventRepository(TicketBookingDbContext ticketBookingDbContext)
        {
            _ticketBookingDbContext = ticketBookingDbContext;
        }

        public async Task<int> AddEventAsync(EventEntity tktEvent)
        {
            await _ticketBookingDbContext.Events.AddAsync(tktEvent);
            return await _ticketBookingDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEventAsync(int eventId)
        {
            var getsEvent = await GetEventByIdAsync(eventId);
            _ticketBookingDbContext.Events.Remove(getsEvent);
            return await _ticketBookingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventEntity>> GetAllEventsAsync()
        {
            return await _ticketBookingDbContext.Events.ToListAsync();
        }

        public async Task<EventEntity> GetEventByIdAsync(int eventId)
        {
            var getEvent = await _ticketBookingDbContext.Events.FindAsync(eventId);
            return getEvent;
        }

        public async Task<int> UpdateEventAsync(EventEntity tktEvent)
        {
            var getEvent = await GetEventByIdAsync(tktEvent.EventId);
            getEvent.EventName = tktEvent.EventName;
            getEvent.Description = tktEvent.Description;
            getEvent.Date=tktEvent.Date;
            getEvent.Venue=tktEvent.Venue;
            getEvent.AvailableSeats= tktEvent.AvailableSeats;
            getEvent.Price=tktEvent.Price;
            getEvent.EventType=tktEvent.EventType;
            _ticketBookingDbContext.Events.Update(getEvent);
            return await _ticketBookingDbContext.SaveChangesAsync();
        }
    }
}
