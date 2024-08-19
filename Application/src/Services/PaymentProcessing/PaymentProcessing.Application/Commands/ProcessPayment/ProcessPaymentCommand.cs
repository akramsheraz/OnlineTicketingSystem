using MediatR;
using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Application.Commands.ProcessPayment
{
    public class ProcessPaymentCommand : IRequest<int>
    {
        public PaymentGatewayType PaymentGatewayType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
    }
}
