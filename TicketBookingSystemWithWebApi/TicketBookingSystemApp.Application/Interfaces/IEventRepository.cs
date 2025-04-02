using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<int> AddEventAsync(Event tktEvent);
        Task<Event> GetEventByIdAsync(int eventId);
        Task<int> DeleteEventAsync(int eventId);
        Task<int> UpdateEventAsync(Event tktEvent);
    }
}
