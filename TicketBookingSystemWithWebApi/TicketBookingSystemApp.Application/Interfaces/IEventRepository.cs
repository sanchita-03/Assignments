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
        Task<IEnumerable<EventEntity>> GetAllEventsAsync();
        Task<int> AddEventAsync(EventEntity tktEvent);
        Task<EventEntity> GetEventByIdAsync(int eventId);
        Task<int> DeleteEventAsync(int eventId);
        Task<int> UpdateEventAsync(EventEntity tktEvent);
    }
}
