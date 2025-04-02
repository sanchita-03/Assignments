using MediatR;
using TicketBookingSystemApp.Application.Interfaces;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand,int>
    {
        readonly IBookingRepository _bookingRepository;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var updateResult = await _bookingRepository.UpdateBookingAsync(request.booking);
            return updateResult;
        }
    }
}
