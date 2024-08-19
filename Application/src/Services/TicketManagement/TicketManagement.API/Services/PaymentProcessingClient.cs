using Grpc.Net.Client;
using MediatR;
using PaymentProcessingClient.Grpc;

namespace TicketManagement.API.Services
{
    public class BookingPaymentProcessingClient : IBookingPaymentProcessingClient
    {
        private readonly ILogger<BookingPaymentProcessingClient> _logger;
        private readonly ISender _sender;

        public BookingPaymentProcessingClient(ILogger<BookingPaymentProcessingClient> logger)
        {
            _logger = logger;            
        }

        public async Task<int> ProcessPayment(int amount)
        {

            using var channel = GrpcChannel.ForAddress("https://localhost:7203");
            var client = new PaymentProtoService.PaymentProtoServiceClient(channel);

            CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest();

            PaymentResponseModel paymentResponseModel = new PaymentResponseModel();
            paymentResponseModel.Amount = amount;

            createPaymentRequest.Payment = paymentResponseModel;

            var reply = await client.CreatePaymentAsync(createPaymentRequest);

            _logger.LogInformation(reply.ToString());
            _logger.LogInformation("payment has been completed");

            return 1;
        }

    }
}
