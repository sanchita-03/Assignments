using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;
using TicketBookingSystemApp.Domain.Constant;
using TicketBookingSystemApp.Infrastructure.Context;

namespace TicketBookingSystemApp.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly TicketBookingDbContext _ticketBookingDbContext;
        public BookingRepository(TicketBookingDbContext ticketBookingDbContext)
        {
            _ticketBookingDbContext = ticketBookingDbContext;
        }
        public async Task<int> AddBookingAsync(Booking booking)
        {
            var userId = await _ticketBookingDbContext.Users.FindAsync(booking.UserId);
            if (userId == null)
            {
                throw new NotFoundException($"User Id {booking.UserId} not found.");
            }
            //var seatNumberList = seats.Split(',')
            //                        .Select(s => int.Parse(s.Trim()))
            //                        .ToList();
            var eventDetails = await _ticketBookingDbContext.Events.FindAsync(booking.EventId);
            if (eventDetails == null)
                throw new NotFoundException($"Event Id {booking.EventId} not found.");

            var availableSeats = await GetAvailableSeatsAsync(booking.EventId);
            var unavailableSeats = booking.SeatNumber.Except(availableSeats).ToList();

            if (unavailableSeats.Any())
                throw new NotFoundException($"Seats {string.Join(", ", unavailableSeats)} are already booked.");

            await _ticketBookingDbContext.Bookings.AddAsync(booking);
            eventDetails.AvailableSeats -= booking.SeatNumber.Count;
            return await _ticketBookingDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteBookingAsync(int bookingId)
        {

            var getBooking = await GetBookingByIdAsync(bookingId);
            var eventDetails = await _ticketBookingDbContext.Events.FindAsync(getBooking.EventId);
            eventDetails.AvailableSeats += getBooking.SeatNumber.Count;
            _ticketBookingDbContext.Bookings.Remove(getBooking);
            return await _ticketBookingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _ticketBookingDbContext.Bookings
                        .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            var getBooking = await _ticketBookingDbContext.Bookings.FindAsync(bookingId);
            return getBooking;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAndEventAsync(int userId, int eventId)
        {
            return await _ticketBookingDbContext.Bookings
                        .Where(b => b.UserId == userId && b.EventId == eventId)
                        .Include(b => b.Event) // Optional: Include event details if needed
                        .Include(b => b.Payment) // Optional: Include payment details if needed
                        .ToListAsync();
        }

        //public async Task<IEnumerable<int>> GetBookedSeatsForEventAsync(int eventId)
        //{
        //    return await _ticketBookingDbContext.BookingSeats
        //        .Where(bs => bs.Booking.EventId == eventId)
        //        .Select(bs => bs.SeatNumber)
        //        .ToListAsync();
        //}


        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            var getBooking = await GetBookingByIdAsync(booking.BookingId);
            var user = await _ticketBookingDbContext.Users.FindAsync(booking.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User Id {booking.UserId} not found.");
            }

            getBooking.UserId = booking.UserId;
            
            getBooking.EventId = booking.EventId;
            getBooking.SeatNumber = booking.SeatNumber;
            //getBooking.BookingDate = booking.BookingDate;
            getBooking.Status = booking.Status;
            
            _ticketBookingDbContext.Bookings.Update(getBooking);
            return await _ticketBookingDbContext.SaveChangesAsync() ;
        }
        public async Task<IEnumerable<int>> GetAvailableSeatsAsync(int eventId)
        {
            // Fetch event details
            var eventDetails = await _ticketBookingDbContext.Events
                .FirstOrDefaultAsync(e => e.EventId == eventId);

            if (eventDetails == null)
                throw new Exception("Event not found.");

            int totalSeats = eventDetails.TotalSeats; // Get total number of seats

            // Fetch booked seats and flatten the List<List<int>> into List<int>
            var bookedSeats = await _ticketBookingDbContext.Bookings
                .Where(b => b.EventId == eventId)
                .Select(b => b.SeatNumber)  // This returns List<List<int>>
                .ToListAsync();

            // Flatten the list of lists to a single List<int>
            var bookedSeatNumbers = bookedSeats.SelectMany(seats => seats).ToList();

            // Generate all seat numbers
            var allSeats = Enumerable.Range(1, totalSeats).ToList();

            // Filter out booked seats
            List<int> availableSeats = allSeats.Except(bookedSeatNumbers).ToList();

            return availableSeats;
        }

        public async Task<Booking> CancelBookingAsync(int bookingId)
        {
            var getBooking = await GetBookingByIdAsync(bookingId);
            //if(getBooking.Status != Status.Cancelled)
            //{
            //    getBooking.Status = Status.Cancelled;
            //}
            //getBooking.SeatNumber = [];
            var eventDetails = await _ticketBookingDbContext.Events.FindAsync(getBooking.EventId);
            eventDetails.AvailableSeats += getBooking.SeatNumber.Count;
            _ticketBookingDbContext.Bookings.Remove(getBooking);
            await _ticketBookingDbContext.SaveChangesAsync();
            return getBooking;

        }
    }
}
