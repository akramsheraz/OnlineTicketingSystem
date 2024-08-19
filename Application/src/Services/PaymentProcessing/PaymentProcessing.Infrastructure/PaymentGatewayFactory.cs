using PaymentProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Infrastructure
{
    public class PaymentGatewayFactory:IPaymentGatewayFactory
    {
        public IPaymentGatewayService Create(PaymentGatewayType gatewayType)
        {
            IPaymentGatewayService paymentGatewayService = null;

            if (gatewayType == PaymentGatewayType.CREDIT_DEBIT_CARDS)
                paymentGatewayService = new PayPalPaymentGatewayService();

            return paymentGatewayService;
        }
    }
}
