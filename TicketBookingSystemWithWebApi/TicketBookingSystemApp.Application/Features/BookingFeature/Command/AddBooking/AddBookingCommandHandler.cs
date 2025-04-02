using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Command.AddBooking
{
    public class AddBookingCommandHandler : IRequestHandler<AddBookingCommand, int>
    {
        readonly IBookingRepository _bookingRepository;
        public AddBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<int> Handle(AddBookingCommand request, CancellationToken cancellationToken)
        {
            int addResult = await _bookingRepository.AddBookingAsync(request.booking);
            return addResult;
        }
    }
}
