using MediatR;
using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Application.Commands.ProcessPayment
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentGatewayFactory _paymentGatewayFactory;

        public ProcessPaymentCommandHandler(IPaymentRepository paymentRepository, IPaymentGatewayFactory paymentGatewayFactory)
        {
            _paymentRepository = paymentRepository;
            _paymentGatewayFactory = paymentGatewayFactory;
        }

        public async Task<int> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentGatewayService = _paymentGatewayFactory.Create(request.PaymentGatewayType);
            var paymentId = await paymentGatewayService.ProcessPaymentAsync(request.Amount, request.Currency, request.PaymentMethod);
            var payment = new Payment
            {
                Id = paymentId,
                Amount = request.Amount,
                Currency = request.Currency,
                PaymentMethod = request.PaymentMethod,
                CreatedAt = DateTime.UtcNow
            };
            await _paymentRepository.AddPaymentAsync(payment);
            return payment.Id;
        }
    }
}
