using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Command.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, int>
    {
        readonly IEventRepository _eventRepository;
        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var getEvent = await _eventRepository.GetEventByIdAsync(request.tktEvent.EventId);
            if (getEvent == null)
            {
                throw new NotFoundException($"Event with Id {request.tktEvent.EventId} not found");
            }
            //return await _eventRepository.DeleteEventAsync(getEvent.EventId);
            return await _eventRepository.UpdateEventAsync(request.tktEvent);
        }
    }
}
