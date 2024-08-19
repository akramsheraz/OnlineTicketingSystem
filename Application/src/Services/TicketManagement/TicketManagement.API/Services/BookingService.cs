using BuildingBlocks.APIModels;
using MediatR;
using TicketManagement.API.Model;
using TicketsManagement.Application.Commnads;
using TicketsManagement.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TicketManagement.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly ILogger<BookingService> _logger;
        private readonly ISender _sender;
        private readonly IBookingPaymentProcessingClient _paymentProcessingClient;
        public BookingService(ILogger<BookingService> logger, ISender sender, IBookingPaymentProcessingClient paymentProcessingClient)
        {
            _logger = logger;
            this._sender = sender;
            this._paymentProcessingClient = paymentProcessingClient;

        }
        public APIResponse ProcessBooking(BookingRequest bookingRquest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {




                BookingData objBooking = new BookingData()
                {
                    EventId = bookingRquest.EventId,
                    SeatId = bookingRquest.SeatId,
                    TicketId = bookingRquest.TicketId,
                    UserId = bookingRquest.UserId,                    
                    Amount = bookingRquest.Amount,
                    PaymentMethod = bookingRquest.PaymentMethod
                };
                
                BookTicketCommand bookTicketCommand = new BookTicketCommand(objBooking);
                var response = _sender.Send(bookTicketCommand);

                if (response.Result != null)
                {
                    apiResponse.Code = "200";
                    apiResponse.Message = "success";

                    var result = _paymentProcessingClient.ProcessPayment(111);
                                        
                    if (result.Id > 0)
                    {
                        // update status of seat to booked  ??????????????????????????????????

                        apiResponse.Code = "200";
                        apiResponse.Message = "success";
                    }
                    else
                    {
                        apiResponse.Code = "400";
                        apiResponse.Message = "events information does not exits";
                    }
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "events information does not exits";
                }

               
            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }
    }
}
