using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessing.Application.Commands.ProcessPayment;
using PaymentProcessing.Domain;

namespace PaymentProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentProcessingController : ControllerBase
    {
        
        private readonly ILogger<PaymentProcessingController> _logger;
        private readonly ISender _sender;

        public PaymentProcessingController(ILogger<PaymentProcessingController> logger, ISender sender)
        {
            _logger = logger;
            this._sender = sender;
        }


        //[HttpPost("GetEvents")]
        //public ActionResult GetEvents()
        //{
        //    Console.WriteLine("create user request started");

        //    GetPaymentQuery query = new GetEventsQuery();
        //    var response = _sender.Send(query);
        //    Console.WriteLine(response.Result);

        //    if (response.Result != null) { return Ok(response.Result); }
        //    else { return BadRequest("events information does not exists"); }
        //}

        [HttpPost("Create")]
        public ActionResult ProcessPayment(Payment objPayment)
        {
            Console.WriteLine("create user request started");

            ProcessPaymentCommand command = new ProcessPaymentCommand();
           // command.objEvent = objEvent;
            var response = _sender.Send(command);

            Console.WriteLine(response.Result);

            if (response.Result != null) { return Ok(response.Result); }
            else { return BadRequest("invalid event information"); }
        }

    }
}
