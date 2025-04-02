using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetBookingsByUserAndEvent
{
    public record GetBookingsByUserAndEventQuery(int userId,int eventId) : IRequest<IEnumerable<Booking>>;
}
