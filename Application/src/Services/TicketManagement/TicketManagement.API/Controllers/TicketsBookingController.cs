using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using TicketManagement.API.Model;
using TicketManagement.API.Services;
using TicketManagement.Application.Queries;
using TicketsManagement.Application.Commnads;
using TicketsManagement.Domain;

namespace TicketsManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketBookingController : ControllerBase
    {
        
        private readonly ILogger<TicketBookingController> _logger;
        private readonly ISender _sender;
        private readonly IBookingService _bookingService;

        public TicketBookingController(ILogger<TicketBookingController> logger, ISender sender , IBookingService bookingService)
        {
            _logger = logger;
            this._sender = sender;
            this._bookingService = bookingService;
        }


        [HttpPost("BookTicket")]
        public ActionResult BookTicket(BookingRequest bookingRequest)
        {

            var APIResponse = _bookingService.ProcessBooking(bookingRequest);

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
