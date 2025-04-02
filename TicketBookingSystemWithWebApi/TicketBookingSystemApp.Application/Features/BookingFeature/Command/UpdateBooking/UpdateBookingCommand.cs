using MediatR;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.UpdateBooking
{
    public record UpdateBookingCommand(Booking booking) : IRequest<int>;  
}
