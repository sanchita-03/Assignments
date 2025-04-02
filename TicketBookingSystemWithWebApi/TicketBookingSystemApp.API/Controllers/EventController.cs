using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingSystemApp.Application.Features.BookingFeature.Query.GetAllEvents;
using TicketBookingSystemApp.Application.Features.EventFeature.Command.AddEvent;
using TicketBookingSystemApp.Application.Features.EventFeature.Command.DeleteEvent;
using TicketBookingSystemApp.Application.Features.EventFeature.Command.UpdateEvent;
using TicketBookingSystemApp.Application.Features.EventFeature.Query.GetEventById;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.API.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var allEvents = await _mediator.Send(new GetAllEventsQuery());
            return Ok(allEvents);
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event tktEvent)
        {
            var allEvents = await _mediator.Send(new AddEventCommand(tktEvent));
            return Ok(allEvents);
        }
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var getEvent = await _mediator.Send(new GetEventByIdQuery(eventId));
            return Ok(getEvent);
        }
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var deleteResult = await _mediator.Send(new DeleteEventCommand(eventId));
            return Ok(deleteResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromBody]Event ticevent)
        {
            var updateResult = await _mediator.Send(new UpdateEventCommand(ticevent));
            return Ok(updateResult);
        }
    }
}
