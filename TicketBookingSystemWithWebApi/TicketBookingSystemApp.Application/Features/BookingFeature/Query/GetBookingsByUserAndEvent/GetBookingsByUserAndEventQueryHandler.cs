using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetBookingsByUserAndEvent
{
    public class GetBookingsByUserAndEventQueryHandler : IRequestHandler<GetBookingsByUserAndEventQuery, IEnumerable<Booking>>
    {
        readonly IBookingRepository _bookingRepository;
        public GetBookingsByUserAndEventQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Task<IEnumerable<Booking>> Handle(GetBookingsByUserAndEventQuery request, CancellationToken cancellationToken)
        {
            var getBookingByUserAndEvent = _bookingRepository.GetBookingsByUserAndEventAsync(request.userId, request.eventId);
            return getBookingByUserAndEvent;
        }
    }
}
