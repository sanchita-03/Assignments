using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Command.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, int>
    {
        readonly IEventRepository _eventRepository;
        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<int> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var addResult = _eventRepository.AddEventAsync(request.tktEvent);
            return addResult;
        }
    }
}

