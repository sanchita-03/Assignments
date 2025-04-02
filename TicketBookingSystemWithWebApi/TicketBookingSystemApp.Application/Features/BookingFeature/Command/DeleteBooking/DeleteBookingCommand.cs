using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.DeleteBooking
{
    public record DeleteBookingCommand(int bookingId) : IRequest<int>;
}
