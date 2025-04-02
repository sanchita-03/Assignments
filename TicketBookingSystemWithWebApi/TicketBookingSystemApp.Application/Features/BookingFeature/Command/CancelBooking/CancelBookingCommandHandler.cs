using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.CancelBooking
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, Booking>
    {
        readonly IBookingRepository _bookingRepository;
        public CancelBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Task<Booking> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var cancelBooking = _bookingRepository.CancelBookingAsync(request.bookingId);
            return cancelBooking;
        }
    }
}
