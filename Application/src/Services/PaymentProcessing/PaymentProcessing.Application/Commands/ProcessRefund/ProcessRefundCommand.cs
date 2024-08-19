using MediatR;
using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Application.Commands.ProcessRefund
{
    public class ProcessRefundCommand : IRequest<bool>
    {
        public PaymentGatewayType PaymentGatewayType { get; set; }
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
    }
}
