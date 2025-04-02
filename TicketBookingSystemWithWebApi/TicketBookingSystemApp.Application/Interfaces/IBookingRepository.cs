using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserAndEventAsync(int userId,int eventId);
        Task<int> AddBookingAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<int> DeleteBookingAsync(int bookingId);
        Task<int> UpdateBookingAsync(Booking booking);
        Task<Booking> CancelBookingAsync(int bookingId);
        Task<IEnumerable<int>> GetAvailableSeatsAsync(int eventId);
    }
}
