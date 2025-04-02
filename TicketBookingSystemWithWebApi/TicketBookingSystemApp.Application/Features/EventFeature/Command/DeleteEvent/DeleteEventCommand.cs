﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Command.DeleteEvent
{
    public record DeleteEventCommand(int eventId) : IRequest<int>;
    
}
