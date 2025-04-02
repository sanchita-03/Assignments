using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAvailableSeatsAsync
{
    public record GetAvailableSeatsQuery(int eventId) : IRequest<IEnumerable<int>>;
}
