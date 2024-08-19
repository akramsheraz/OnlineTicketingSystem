using EventManagement.Application.Queries;
using EventManagement.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Domain;
using EventManagement.API.Services;
using EventManagement.API.Models;
using Microsoft.Extensions.Logging;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        
        private readonly ILogger<EventsController> _logger;
        private readonly ISender _sender;
        private readonly EventService _eventService;

        public EventsController(ILogger<EventsController> logger, ISender sender , EventService eventService)
        {
            _logger = logger;
            this._sender = sender;
            this._eventService = eventService;
        }


        [HttpGet("SearchEvents")]
        public ActionResult GetEvents(SearchEventsRequest getEventsRequest)
        {
            var APIResponse = _eventService.GetEvents(getEventsRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }

        [HttpPost("AddEvent")]
        public ActionResult AddEvent(AddEventRequest eventRequest)
        {
            var APIResponse = _eventService.AddEvent(eventRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }

        [HttpPost("EditEvent")]
        public ActionResult EditEvent(EditEventRequest objEventRequest)
        {
            var APIResponse = _eventService.EditEvent(objEventRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }

        }

        [HttpPost("DeleteEvent")]
        public ActionResult DeleteEvent(DeleteEventRequest deleteEventRequest)
        {
            var APIResponse = _eventService.DeleteEvent(deleteEventRequest.EventId);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }
               
    }
}
