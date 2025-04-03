using MediatR;
using TicketBookingSystemApp.Application.Interfaces;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventEntity>>
    {
        readonly IEventRepository _eventRepository;
        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventEntity>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _eventRepository.GetAllEventsAsync();
            return allEvents;
        }
    }
}
