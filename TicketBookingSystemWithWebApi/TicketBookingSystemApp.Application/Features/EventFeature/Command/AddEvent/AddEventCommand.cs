﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Application.Features.EventFeature.Command.AddEvent
{
    public record AddEventCommand(EventEntity tktEvent):IRequest<int>;
}
