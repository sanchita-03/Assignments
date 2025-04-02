using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Command.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
    {
        readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var getEvent = await _eventRepository.GetEventByIdAsync(request.eventId);
            if (getEvent == null)
            {
                throw new NotFoundException($"Event with Id {request.eventId} not found");
            }
            return await _eventRepository.DeleteEventAsync(getEvent.EventId);
        }
    }
}
