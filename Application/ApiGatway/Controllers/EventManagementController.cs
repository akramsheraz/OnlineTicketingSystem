using MediatR;
using Microsoft.AspNetCore.Mvc;





namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventManagementController : ControllerBase
    {
        
        private readonly ILogger<EventManagementController> _logger;
        private readonly ISender _sender;

        public EventManagementController(ILogger<EventManagementController> logger, ISender sender)
        {
            _logger = logger;
            this._sender = sender;
        }


        [HttpPost("GetEvents")]
        public ActionResult GetEvents()
        {
            Console.WriteLine("create user request started");

            GetEventsQuery query = new GetEventsQuery();
            var response = _sender.Send(query);
            Console.WriteLine(response.Result);

            if (response.Result != null) { return Ok(response.Result); }
            else { return BadRequest("events information does not exists"); }
        }

        [HttpPost("Create")]
        public ActionResult Create(Event objEvent)
        {
            Console.WriteLine("create user request started");

            CreateEventCommand command = new CreateEventCommand();
            command.objEvent = objEvent;
            var response =  _sender.Send(command);
            Console.WriteLine(response.Result);

            if (response.Result != null) { return Ok(response.Result);}
            else { return BadRequest("invalid event information"); }            
        }

        [HttpPost("Edit")]
        public ActionResult Edit(Event objEvent)
        {
            Console.WriteLine("create user request started");

            UpdateEventCommand command = new UpdateEventCommand();
            command.updateEvent = objEvent;
            var response = _sender.Send(command);
            Console.WriteLine(response.Result);

            if (response.Result != null) { return Ok(response.Result); }
            else { return BadRequest("invalid event information"); }
        }

        [HttpPost("Delete")]
        public ActionResult Delete(Guid eventId)
        {
            Console.WriteLine("Logout user request started");

            DeleteEventCommand command = new DeleteEventCommand(eventId);
            var logOutCommandResult = _sender.Send(command);

            if (logOutCommandResult.Result != null) { return Ok(logOutCommandResult.Result); }
            else { return BadRequest("invalid user information"); }           
        }
               
    }
}
