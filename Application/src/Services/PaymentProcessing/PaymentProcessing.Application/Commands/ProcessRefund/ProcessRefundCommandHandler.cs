using MediatR;
using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Application.Commands.ProcessRefund
{
    public class ProcessRefundCommandHandler : IRequestHandler<ProcessRefundCommand, bool>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentGatewayFactory _paymentGatewayFactory;

        public ProcessRefundCommandHandler(IPaymentRepository paymentRepository, IPaymentGatewayFactory paymentGatewayFactory)
        {
            _paymentRepository = paymentRepository;
            _paymentGatewayFactory = paymentGatewayFactory;
        }

        public async Task<bool> Handle(ProcessRefundCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(request.PaymentId);
            if (payment == null)
            {
                throw new NotFoundException(nameof(Payment), request.PaymentId);
            }
            var paymentGatewayService = _paymentGatewayFactory.Create(request.PaymentGatewayType);
            var result = await paymentGatewayService.ProcessRefundAsync(request.PaymentId, request.Amount);
            if (result)
            {
                payment.Amount -= request.Amount;
                await _paymentRepository.UpdatePaymentAsync(payment);
            }
            return result;
        }
    }
}
