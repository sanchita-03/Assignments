using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketBookingSystemApp.Application.Features.BookingFeature.Command.AddBooking;
using TicketBookingSystemApp.Application.Features.BookingFeature.Command.CancelBooking;
using TicketBookingSystemApp.Application.Features.BookingFeature.Command.DeleteBooking;
using TicketBookingSystemApp.Application.Features.BookingFeature.Command.UpdateBooking;
using TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAllBookings;
using TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAvailableSeatsAsync;
using TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetBookingById;
using TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetBookingsByUserAndEvent;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var getBookings = await _mediator.Send(new GetAllBookingsQuery());
            return Ok(getBookings);
        }

        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetBookingById(int bookingId)
        {
            var getBooking = await _mediator.Send(new GetBookingByIdQuery(bookingId));
            return Ok(getBooking);
        }
        [HttpGet("available-seats/{eventId}")]
        public async Task<IActionResult> GetAvailableSeats(int eventId)
        {
            var getSeats = await _mediator.Send(new GetAvailableSeatsQuery(eventId));
            return Ok(getSeats);
        }
        [HttpPut("cancelBooking/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var getSeats = await _mediator.Send(new CancelBookingCommand(bookingId));
            return Ok(getSeats);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            var addResult = await _mediator.Send(new AddBookingCommand(booking));
            return Ok(addResult);
        }

        [HttpGet("user/{userId}/event/{eventId}")]
        public async Task<IActionResult> GetBookingsByUserAndEvent(int userId, int eventId)
        {
            var bookings = await _mediator.Send(new GetBookingsByUserAndEventQuery(userId, eventId));
            if (bookings == null || !bookings.Any())
                return NotFound("No bookings found for this user and event.");

            return Ok(bookings);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            var deleteResult = await _mediator.Send(new DeleteBookingCommand(bookingId));
            return Ok(deleteResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(Booking booking)
        {
            var updateResult = await _mediator.Send(new UpdateBookingCommand(booking));
            return Ok(updateResult);
        }

    }
}
