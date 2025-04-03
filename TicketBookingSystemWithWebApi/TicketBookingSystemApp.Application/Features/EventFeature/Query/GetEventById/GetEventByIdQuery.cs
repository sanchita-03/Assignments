using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Query.GetEventById
{
    public record GetEventByIdQuery(int eventId) : IRequest<EventEntity>;
    
}
