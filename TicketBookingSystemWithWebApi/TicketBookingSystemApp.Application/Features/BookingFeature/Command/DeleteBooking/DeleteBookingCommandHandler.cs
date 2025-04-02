using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        readonly IBookingRepository _bookingRepository;
        public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<int> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var deleteResult = await _bookingRepository.DeleteBookingAsync(request.bookingId);
            return deleteResult;
        }
    }
}
