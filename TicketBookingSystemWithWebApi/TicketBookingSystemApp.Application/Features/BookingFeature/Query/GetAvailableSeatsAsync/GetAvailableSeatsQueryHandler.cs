using MediatR;
using TicketBookingSystemApp.Application.Interfaces;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAvailableSeatsAsync
{
    public class GetAvailableSeatsQueryHandler : IRequestHandler<GetAvailableSeatsQuery, IEnumerable<int>>
    {
        readonly IBookingRepository _bookingRepository;
        public GetAvailableSeatsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Task<IEnumerable<int>> Handle(GetAvailableSeatsQuery request, CancellationToken cancellationToken)
        {
            var availableSeats = _bookingRepository.GetAvailableSeatsAsync(request.eventId);
            return availableSeats; 
        }
    }
}
