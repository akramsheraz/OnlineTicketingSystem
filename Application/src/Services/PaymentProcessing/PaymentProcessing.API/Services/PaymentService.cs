using Grpc.Core;
using Mapster;
using PaymentProcessing.Domain;
using PaymentProcessing.Grpc;

namespace PaymentProcessing.Grpc.Services;

public class PaymentService    (/*DiscountContext dbContext, */ILogger<PaymentService> logger)
    : PaymentProtoService.PaymentProtoServiceBase
{

    public override async Task<PaymentResponseModel> CreatePayment(CreatePaymentRequest request, ServerCallContext context)
    {
        logger.LogInformation("Payment request has been  started");

        var payment = request.Payment;
        if (payment is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
                

        logger.LogInformation("Payment is successfully done. Payment Id : {PaymentId}", payment.Id);

        var paymentResponseModel = payment.Adapt<PaymentResponseModel>();
        return paymentResponseModel;
    }


}
