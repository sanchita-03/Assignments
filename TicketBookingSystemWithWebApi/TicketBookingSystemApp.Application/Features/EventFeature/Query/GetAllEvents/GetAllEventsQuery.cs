using MediatR;
using TicketBookingSystemApp.Domain;


namespace TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAllEvents
{
    public record class GetAllEventsQuery(): IRequest<IEnumerable<Event>>;
    
}
