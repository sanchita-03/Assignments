using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Exceptions;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Query.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        readonly IEventRepository _eventRepository;
        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var getEvent = await _eventRepository.GetEventByIdAsync(request.eventId);
            if (getEvent == null)
            {
                throw new NotFoundException($"Event with Id {request.eventId} not found");
            }
            return getEvent;
        }
    }
}
