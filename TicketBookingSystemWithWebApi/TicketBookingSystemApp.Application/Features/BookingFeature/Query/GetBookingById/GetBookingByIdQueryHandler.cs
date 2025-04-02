using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetBookingById
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
    {
        readonly IBookingRepository _bookingRepository;
        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var getBooking = await _bookingRepository.GetBookingByIdAsync(request.bookingId);
            return getBooking;
        }
    }
}
